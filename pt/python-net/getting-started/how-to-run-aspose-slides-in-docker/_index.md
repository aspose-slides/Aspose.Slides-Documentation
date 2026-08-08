---
title: Como executar Aspose.Slides no Docker
linktitle: Aspose.Slides no Docker
type: docs
weight: 150
url: /pt/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Aspose.Slides no Docker
- Contêiner Docker
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- fontes
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Execute Aspose.Slides para Python via .NET no Docker: um Dockerfile funcional, as bibliotecas nativas que o pacote necessita, configuração de fontes e licenciamento dentro de um contêiner."
---
## **Visão geral**

Aspose.Slides for Python via .NET roda em contêineres Linux, mas o pacote é um wrapper Python em torno de um runtime .NET Core 3.1 incluído. Esse runtime necessita de três bibliotecas nativas que as imagens slim de Python não incluem, e ele é exigente quanto às versões. Este artigo fornece um Dockerfile que funciona, explica por que cada dependência está presente e mostra como adicionar fontes e uma licença.

## **Um Dockerfile funcional**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

Compilar e executar:

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **Por que a imagem base é Debian 11**

O wheel `aspose.slides` inclui um runtime **.NET Core 3.1**, e esse runtime antecede as versões das bibliotecas fornecidas pelas versões atuais do Debian. No Debian 12 e 13 o contêiner é construído com sucesso e então falha na primeira chamada `Presentation()`:

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

A mensagem é enganosa — o ICU *está* instalado nessas imagens, mas é ICU 72 ou 76, e o .NET Core 3.1 reconhece apenas versões principais mais antigas. O Debian 12 também inclui OpenSSL 3, o que gera uma segunda falha:

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` é Debian 11, que fornece ambas as versões que o runtime incluído espera:

| Pacote | Versão no Debian 11 | Por que é necessário |
|---|---|---|
| `libgdiplus` | 6.0.4 | Implementação GDI+ usada para renderizar formas, texto e imagens |
| `libicu67` | 67.1 | Dados de globalização. Versões principais mais recentes não são reconhecidas pelo .NET Core 3.1 |
| `libssl1.1` | 1.1.1w | Criptografia. Pré-instalada no Debian 11; ausente no Debian 12+ |
| `libfontconfig1` | — | Descoberta de fontes |

`libssl1.1` já está presente na imagem base, portanto não precisa ser listado em `apt-get install`.

Se for necessário usar uma imagem base mais recente, defina `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` para contornar o requisito do ICU. Isso desabilita a formatação específica de cultura e **não** resolve o problema do OpenSSL, portanto o Debian 11 continua sendo a escolha mais simples.

## **Fontes**

As imagens slim não contêm fontes. Sem ao menos uma fonte instalada, o texto é renderizado como caixas em branco em saída PDF, imagem e HTML. `fonts-dejavu-core` é um pequeno ponto de partida de uso geral.

Para corresponder à aparência pretendida da apresentação, copie as fontes que ela usa para a imagem e aponte o Aspose.Slides para elas:

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **Licenciamento dentro de um contêiner**

Não inclua o arquivo de licença na imagem — quem que baixar a imagem recebe a licença. Monte-a em tempo de execução ao invés disso:

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

Sem uma licença a biblioteca funciona em modo de avaliação, o que adiciona uma marca d'água e limita o número de slides processados. Veja [Licenciamento](/slides/pt/python-net/licensing/) para detalhes.

## **Memória**

A renderização para PDF ou imagens consome mais memória do que a leitura de um arquivo. Contêineres com limites de memória restritos podem ser terminados pelo OOM killer no meio de uma conversão, o que geralmente se manifesta como o processo desaparecendo sem um traceback do Python. Se isso ocorrer, aumente o limite de memória do contêiner antes de investigar o código.