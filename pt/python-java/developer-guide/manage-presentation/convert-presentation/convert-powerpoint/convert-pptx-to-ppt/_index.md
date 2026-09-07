---
title: Converter PPTX para PPT em Python
linktitle: PPTX para PPT
type: docs
weight: 21
url: /pt/python-java/convert-pptx-to-ppt/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPTX
- PPTX para PPT
- salvar PPTX como PPT
- exportar PPTX para PPT
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Converter PPTX para formato legado PPT em Python com Aspose.Slides for Python via Java. Inclui um exemplo de código e notas sobre compatibilidade e arquivos protegidos."
---
## **Visão geral**

O Aspose.Slides for Python via Java permite converter uma apresentação PPTX para o formato legado PPT usado pelo PowerPoint 97–2003 sem que o Microsoft PowerPoint esteja instalado. Carregue o arquivo PPTX e salve‑o no formato de saída PPT, como mostrado abaixo.

## **Converter PPTX para PPT**

Carregue o arquivo de origem com a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/). Em seguida, chame [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) passando o caminho de saída e [SaveFormat.Ppt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Ppt).

O exemplo a seguir inicia a máquina virtual Java, se necessário, e converte `template.pptx` para `output.ppt` usando as opções padrão. Substitua os caminhos pelos nomes de arquivos desejados. O bloco `finally` libera os recursos da apresentação mesmo se a gravação falhar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carregar a apresentação PPTX.
presentation = Presentation("template.pptx")
try:
    # Salvar a apresentação no formato PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

O argumento [SaveFormat.Ppt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/#Ppt) seleciona o formato de saída; alterar apenas a extensão do arquivo não converte uma apresentação. Mantenha o arquivo PPTX original para que você possa retornar a ele caso um recurso mais recente não tenha equivalente no PPT.

## **Converter PPTX para Outros Formatos**

O Aspose.Slides também oferece suporte a outros formatos de saída. Consulte os artigos correspondentes para opções e exemplos específicos de cada formato:

- [Converter PowerPoint para PDF em Python](/slides/pt/python-java/convert-powerpoint-to-pdf/)
- [Converter PowerPoint para XPS em Python](/slides/pt/python-java/convert-powerpoint-to-xps/)
- [Converter PowerPoint para HTML em Python](/slides/pt/python-java/convert-powerpoint-to-html/)
- [Salvar apresentações como ODP em Python](/slides/pt/python-java/save-presentation/)
- [Converter PowerPoint para PNG em Python](/slides/pt/python-java/convert-powerpoint-to-png/)

## **Perguntas frequentes**

**Todos os efeitos e recursos do PPTX permanecem após a conversão para PPT?**

Nem sempre. O formato legado PPT não oferece suporte a todos os recursos disponíveis no PPTX. Alguns efeitos, objetos ou comportamentos podem ser simplificados ou exibidos de forma diferente. Revise a apresentação convertida no visualizador pretendido, especialmente quando ela contém recursos mais recentes do PowerPoint.

**Posso converter apenas slides selecionados para PPT?**

Salvar como PPT grava toda a apresentação. Para converter slides selecionados, crie uma nova apresentação, remova seu slide inicial vazio, clone os slides necessários para ela e salve como PPT. Consulte [Clone Slides in Python](/slides/pt/python-java/clone-slides/).

**Posso converter um arquivo PPTX protegido por senha?**

Sim, se você fornecer a senha correta ao carregar a apresentação de origem. Você também pode configurar a proteção para o arquivo de saída. Consulte [Password-Protected Presentations](/slides/pt/python-java/password-protected-presentation/).