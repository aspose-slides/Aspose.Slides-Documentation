---
title: Converter PPT para PPTX em Python
linktitle: PPT para PPTX
type: docs
weight: 20
url: /pt/python-java/convert-ppt-to-pptx/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- PPT para PPTX
- salvar PPT como PPTX
- exportar PPT para PPTX
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Converter arquivos PPT legados para PPTX em Python com Aspose.Slides. Inclui exemplos Python para conversão de arquivo único e em lote, tratamento de erros e notas de fidelidade."
---
## **Visão geral**

PPT é o formato binário legado do PowerPoint, enquanto PPTX é o formato Open XML mais recente. Aspose.Slides para Python via Java pode carregar um arquivo PPT e salvá‑lo como PPTX sem o Microsoft PowerPoint. Este artigo mostra como converter um arquivo ou um diretório de arquivos e explica o que verificar após a conversão.

Cada exemplo inicia a máquina virtual Java, se necessário, e libera a apresentação após o uso. Substitua os caminhos de exemplo pelos seus próprios caminhos de arquivo ou diretório.

## **Converter um arquivo PPT para PPTX**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/), em seguida chame [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) com [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Pptx). O bloco `finally` descarta a apresentação e libera seus recursos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carregar a apresentação PPT legada.
presentation = Presentation("presentation.ppt")
try:
    # Salvar a apresentação no formato PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A extensão do arquivo não seleciona o formato de saída por si só; o argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Pptx) faz isso. Mantenha os caminhos de entrada e saída diferentes se precisar preservar o arquivo PPT original.

## **Converter vários arquivos PPT**

O exemplo a seguir converte cada arquivo `.ppt` em um diretório. Cada arquivo é processado de forma independente, portanto, uma falha de conversão não interrompe o restante do lote.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Para cargas de trabalho de produção, registre a exceção completa, decida se um arquivo de saída existente pode ser sobrescrito e grave os nomes dos arquivos que falharam em uma fila de re‑tentativa ou revisão. Arquivos corrompidos, arquivos protegidos por senha abertos sem a senha necessária, caminhos inacessíveis e conteúdo não suportado podem causar a falha da conversão. Consulte [Apresentações protegidas por senha](/slides/pt/python-java/password-protected-presentation/) para carregar arquivos criptografados.

## **Fidelidade e recursos legados**

A conversão normalmente preserva slides, mestres, layouts, texto, formas, imagens, tabelas e gráficos. No entanto, PPT e PPTX não representam todos os recursos exatamente da mesma forma. Um recurso legado que não possui equivalente em PPTX ou que não é suportado pela biblioteca pode ser normalizado, omitido ou exibido de maneira diferente.

Verifique o arquivo convertido quando ele contiver animações, transições, objetos OLE incorporados ou vinculados, controles ActiveX, mídia incorporada, fontes incomuns ou macros VBA. Um arquivo PPTX simples não é um formato habilitado para macros, portanto use um fluxo de trabalho adequado a macros quando o VBA precisar permanecer disponível. Também verifique se as fontes necessárias e os recursos externos estão presentes no ambiente onde a apresentação convertida será aberta ou renderizada.

Para documentos importantes, reabra programaticamente o PPTX gerado e inspecione contagens e conteúdo de slides essenciais, então compare sua aparência e comportamento de apresentação no visualizador pretendido. Não considere uma chamada bem‑sucedida a [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) como prova de que cada recurso legado tem uma representação PPTX exata.

## **Quando usar PPTX**

Use PPTX quando a apresentação for editada nas versões atuais do PowerPoint, trocada com sistemas que trabalham com pacotes Open XML ou armazenada em um formato mais fácil de inspecionar e recuperar do que o binário legado PPT. Mantenha o PPT original como uma cópia de arquivo ou de reversão até que a apresentação convertida passe em suas verificações de fidelidade.

Se precisar de PDF, HTML, imagens, XPS ou outro tipo de saída, use as orientações específicas de formato em [Convert Presentations to Multiple Formats](/slides/pt/python-java/convert-presentation/) em vez de assumir que todos os destinos preservam recursos editáveis do PowerPoint.

## **Conversor online**

Para um arquivo ocasional ou uma comparação rápida, você pode usar o [online PPT to PPTX converter](https://products.aspose.app/slides/pt/conversion/ppt-to-pptx). Para conversões repetíveis, processamento em lote ou tratamento de erros em nível de aplicação, use a API Python via Java.

## **Artigos relacionados**

- [PPT vs PPTX](/slides/pt/python-java/ppt-vs-pptx/)
- [Salvar apresentações em Python](/slides/pt/python-java/save-presentation/)
- [Formatos de arquivo suportados](/slides/pt/python-java/supported-file-formats/)
- [Abrir apresentações em Python](/slides/pt/python-java/open-presentation/)

## **FAQ**

**Posso converter PPT para PPTX sem o Microsoft PowerPoint instalado?**

Sim. Aspose.Slides para Python via Java carrega e salva arquivos de apresentação sem exigir o Microsoft PowerPoint.

**A conversão de PPT para PPTX preservará todo o conteúdo exatamente?**

Ele preserva o conteúdo comum das apresentações, mas a fidelidade exata não é garantida para todo recurso legado ou não suportado. Revise o arquivo gerado quando ele contiver macros, objetos OLE ou ActiveX, mídia, animações especializadas ou fontes incomuns.

**Posso converter um arquivo PPT protegido por senha?**

Sim, se você fornecer a senha correta ao carregar o arquivo. Uma senha ausente ou incorreta faz com que a operação de carregamento falhe.

**Devo excluir o arquivo PPT após a conversão?**

Mantenha o original até que você tenha verificado o PPTX nos visualizadores e fluxos de trabalho que importam para você. Isso fornece uma cópia de reversão caso um recurso legado seja convertido de forma diferente.