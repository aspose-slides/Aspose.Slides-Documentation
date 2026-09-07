---
title: Converter ODP para PPTX em Python
linktitle: ODP para PPTX
type: docs
weight: 10
url: /pt/python-java/convert-odp-to-pptx/
keywords:
- converter OpenDocument
- converter apresentação
- converter slide
- converter ODP
- OpenDocument para PPTX
- ODP para PPTX
- salvar ODP como PPTX
- exportar ODP para PPTX
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Converta apresentações ODP para PPTX com Aspose.Slides for Python via Java. Use um exemplo completo em Python sem instalar o PowerPoint ou o LibreOffice."
---
## **Visão geral**

Este artigo explica como converter uma apresentação OpenDocument (ODP) para o formato PowerPoint (PPTX) usando Aspose.Slides for Python via Java.

## **Converter ODP para PPTX**

A classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) pode carregar um arquivo ODP diretamente. Salve a apresentação carregada no formato PPTX usando [SaveFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveformat/).

Siga as [installation instructions](/slides/pt/python-java/installation/) antes de executar o exemplo. Coloque uma apresentação ODP chamada `AccessOpenDoc.odp` no diretório de trabalho. O código a seguir inicia a JVM se necessário, abre o arquivo ODP e o salva como `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpaye.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Salve a apresentação ODP no formato PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Exemplo ao Vivo**

Teste o aplicativo web [Aspose.Slides Conversion](https://products.aspose.app/slides/pt/conversion/) para ver a conversão de ODP para PPTX alimentada pelo Aspose.Slides.

## **FAQ**

**Preciso instalar o Microsoft PowerPoint ou o LibreOffice para converter ODP para PPTX?**

Não. Aspose.Slides for Python via Java lê e grava arquivos de apresentação sem nenhum desses aplicativos. Você precisa apenas do pacote Python e de um runtime Java compatível.

**Slides mestre, layouts e temas são preservados durante a conversão?**

Aspose.Slides mapeia a estrutura e a formatação da apresentação de origem para PPTX. No entanto, ODP e PPTX suportam recursos diferentes, portanto alguns elementos podem aparecer de forma distinta após a conversão. Disponibilize as fontes necessárias e revise apresentações com formatação complexa. Consulte [OpenDocument conversion](/slides/pt/python-java/convert-openoffice-odp/) para considerações de compatibilidade.

**Posso converter arquivos ODP protegidos por senha?**

Sim, quando você fornece a senha necessária para abrir o arquivo. Veja [password-protected presentations](/slides/pt/python-java/password-protected-presentation/) para detalhes sobre como carregar arquivos protegidos antes de salvá‑los em outro formato.

**Aspose.Slides é adequado para serviços de conversão em nuvem ou baseados em REST?**

Sim. Você pode usar Aspose.Slides for Python via Java em seu backend com o runtime Java necessário. Para uma API REST, consulte [Aspose.Slides Cloud](https://products.aspose.cloud/slides/pt/family/).