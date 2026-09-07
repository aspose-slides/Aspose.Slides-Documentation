---
title: Converter apresentações PowerPoint para documentos Word em Python via Java
linktitle: PowerPoint para Word
type: docs
weight: 110
url: /pt/python-java/convert-powerpoint-to-word/
keywords:
- converter PowerPoint
- converter apresentação
- PowerPoint para Word
- apresentação para Word
- PPT para Word
- PPTX para Word
- ODP para Word
- PowerPoint para DOCX
- PPT para DOCX
- PPTX para DOCX
- PowerPoint para DOC
- salvar PPT como DOCX
- salvar PPTX como DOCX
- exportar PPT para DOCX
- exportar PPTX para DOCX
- Python
- Java
- Aspose.Slides
description: "Converter apresentações PowerPoint e OpenDocument para Word em Python via Java com Aspose.Slides e Aspose.Words, combinando imagens dos slides com texto editável."
---
## **Visão geral**

Este artigo explica como converter apresentações PowerPoint e OpenDocument para documentos Word usando Aspose.Slides para Python via Java junto com Aspose.Words para Java. Aspose.Slides renderiza cada slide e lê seu texto, enquanto Aspose.Words cria o documento Word através do JPype. O Microsoft Office não é necessário.

O documento resultante contém uma imagem do slide seguida do texto editável extraído das formas automáticas de nível superior desse slide. A imagem preserva a aparência visual do slide; formas individuais, gráficos e tabelas não são convertidos em objetos editáveis do Word. O texto extraído não mantém a formatação ou o posicionamento original.

## **Converter PowerPoint para Word**

1. Instale [Aspose.Slides para Python via Java](/slides/pt/python-java/installation/) e um runtime Java compatível.  
2. Baixe [Aspose.Words para Java](https://releases.aspose.com/words/java/). Coloque seu arquivo JAR principal em um diretório `lib` ao lado do seu script e renomeie‑o para `aspose-words.jar`, ou ajuste o caminho no exemplo para corresponder ao arquivo baixado.  
3. Coloque a apresentação de entrada, `sample.pptx`, no diretório de trabalho. O caminho `lib/aspose-words.jar` também é relativo a esse diretório.  
4. Execute o código Python a seguir para criar `output.docx`.

O exemplo carrega a fonte com [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) e renderiza os slides com [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage). Ele usa [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) do Aspose.Words para inserir as imagens e o texto no documento Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Ajuste a imagem do slide à largura da área de texto, preservando sua proporção.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Anexe texto simples das formas automáticas de nível superior, incluindo caixas de texto.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Cada slide começa em uma nova página. Texto extraído longo ou imagens de slide incomumente altas podem exigir páginas adicionais. O código adiciona quebras de página somente entre slides e libera a apresentação e as imagens renderizadas em blocos `finally`. A JVM permanece disponível para conversões subsequentes no mesmo processo Python.

## **Perguntas frequentes**

**Quais bibliotecas são necessárias?**

Use Aspose.Slides para Python via Java, JPype, um runtime Java compatível e Aspose.Words para Java. Ambas as bibliotecas Aspose são executadas na mesma JVM. Aspose.Slides trata da apresentação; Aspose.Words grava o documento Word.

**Posso converter arquivos PPT e ODP além de PPTX?**

Sim. Substitua `sample.pptx` por um arquivo PPT ou ODP. Consulte [Supported File Formats](/slides/pt/python-java/supported-file-formats/) para os formatos de entrada de apresentação suportados.

**Todo o conteúdo do slide é editável no Word?**

Não. Cada slide é inserido como uma imagem estática, com texto simples das formas automáticas de nível superior adicionado abaixo. Texto dentro de grupos, tabelas, SmartArt e gráficos, bem como notas de apresentação, não é extraído por este exemplo. Animações e transições não são reproduzidas no documento Word.

**Posso salvar como DOC em vez de DOCX?**

Sim. Altere o nome do arquivo de saída para `output.doc`. Aspose.Words seleciona o formato de saída a partir da extensão do nome do arquivo ao usar esta sobrecarga de salvamento.