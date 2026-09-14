---
title: Gerenciar Cabeçalhos e Rodapés da Apresentação em Python via Java
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/python-java/presentation-header-and-footer/
keywords:
- cabeçalho
- texto do cabeçalho
- rodapé
- texto do rodapé
- definir cabeçalho
- definir rodapé
- folheto
- notas
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Aprenda como gerenciar os marcadores de posição de rodapé, data/hora, número do slide e cabeçalho em slides, páginas de notas e folhetos com Aspose.Slides para Python via Java."
---
## **Visão geral**

O PowerPoint usa diferentes marcadores de posição de cabeçalho e rodapé dependendo do tipo de página. Aspose.Slides for Python via Java permite controlar o texto e a visibilidade desses marcadores de posição através de classes de gerenciamento de cabeçalho/rodapé.

Os marcadores de posição disponíveis dependem do escopo:

| Escopo | Cabeçalho | Rodapé | Data/hora | Número do slide/página |
|---|---|---|---|---|
| Slide regular | Não | Sim | Sim | Sim |
| Mestre de notas | Sim | Sim | Sim | Sim |
| Slide de notas | Sim | Sim | Sim | Sim |
| Mestre de folhetos | Sim | Sim | Sim | Sim |

Um slide de apresentação regular não possui um marcador de posição de cabeçalho. Os cabeçalhos estão disponíveis em páginas de notas e folhetos. Para slides regulares, use os marcadores de posição de rodapé, data/hora e número do slide.

O escopo de uma alteração depende do gerenciador que você usa. A classe [SlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideheaderfootermanager/) controla um slide regular. A classe [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notesslideheaderfootermanager/) controla um slide de notas. Gerenciadores de mestre e layout também podem propagar configurações para slides dependentes, enquanto a classe [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) controla o mestre de folhetos.

## **Definir Rodapé, Data/Hora e Números de Slides em Slides Regulares**

Para slides regulares, o fluxo de trabalho básico é acessar o gerenciador de cabeçalho/rodapé de cada slide, definir o texto do rodapé e da data/hora, habilitar os marcadores de posição necessários e salvar a apresentação. Os números de slide são gerados pela apresentação, portanto você só precisa controlar sua visibilidade.

Use [setFooterText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) e [setDateTimeText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) para definir o texto, e use [setFooterVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) e [setSlideNumberVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) para exibir os respectivos marcadores de posição.

O exemplo completo a seguir aplica o mesmo rodapé, texto de data/hora e visibilidade de número de slide a todos os slides regulares:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se precisar atualizar apenas um slide, acesse esse slide diretamente através do método [getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides) em vez de iterar por toda a coleção.

## **Definir Cabeçalhos e Rodapés no Mestre de Notas**

O mestre de notas define a formatação comum e o comportamento dos marcadores de posição para páginas de notas. Use a classe [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/) quando quiser alterar apenas o próprio mestre de notas.

O exemplo a seguir define texto de cabeçalho, rodapé e data/hora no mestre de notas e torna todos os marcadores de posição suportados visíveis naquele mestre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O método `getMasterNotesSlide` retorna `None` quando a apresentação não contém um mestre de notas.

## **Aplicar Configurações do Mestre de Notas aos Slides de Notas Filhos**

Um mestre de notas pode aplicar configurações de cabeçalho e rodapé a si próprio e a todos os slides de notas dependentes. Use os métodos de propagação dedicados em [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/) quando as mesmas configurações devem ser aplicadas em toda a hierarquia de notas.

Por exemplo, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) e [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) atualizam o cabeçalho do mestre de notas e todos os cabeçalhos filhos. Métodos equivalentes estão disponíveis para rodapés, data/hora e números de slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Os métodos de propagação usados acima são [setFooterAndChildFootersText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) e [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Definir Cabeçalhos e Rodapés em um Slide de Notas Individual**

Um slide de notas pertence a um slide regular específico. Use sua classe [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notesslideheaderfootermanager/) quando quiser personalizar apenas aquela página de notas.

O método [addNotesSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notesslidemanager/#addNotesSlide) retorna o slide de notas para o slide atual e cria um caso não exista. O exemplo a seguir configura a página de notas associada ao primeiro slide da apresentação:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Se primeiro você propagar as configurações do mestre de notas e depois alterar um slide de notas individual, as configurações posteriores por slide permitem personalizar aquela página de notas de forma independente.

## **Definir Cabeçalhos e Rodapés no Mestre de Folhetos**

Páginas de folhetos usam o mestre de folhetos para seus marcadores de posição de cabeçalho, rodapé, data/hora e número de página. Ao contrário das páginas de notas, as configurações de folheto são gerenciadas através do mestre de folhetos e não por slides individuais de folheto.

Use o método `getMasterHandoutSlide` para acessar o mestre de folhetos. Se ele não estiver presente, chame `setDefaultMasterHandoutSlide` para criar o mestre de folhetos padrão.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Entender Escopo e Herança**

Escolha o gerenciador de cabeçalho/rodapé que corresponde ao escopo que você deseja alterar:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slideheaderfootermanager/) altera as configurações de rodapé, data/hora e número de slide para um slide regular.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layoutslideheaderfootermanager/) controla um slide de layout e pode propagar as configurações suportadas para slides dependentes.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterslideheaderfootermanager/) controla um mestre de slide regular e pode propagar as configurações suportadas para slides dependentes.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masternotesslideheaderfootermanager/) controla o mestre de notas e pode propagar as configurações para todos os slides de notas dependentes.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/notesslideheaderfootermanager/) altera um slide de notas e suporta um marcador de posição de cabeçalho além de rodapé, data/hora e número de slide.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) altera o mestre de folhetos e suporta todos os quatro tipos de marcadores de posição.

Use a propagação a partir de um mestre ou layout quando a mesma configuração deve ser aplicada em toda a sua hierarquia. Use um gerenciador de slide individual ou de slide de notas quando precisar de uma configuração local para uma página.

## **Perguntas frequentes**

**Posso adicionar um cabeçalho a um slide regular?**

Não. O PowerPoint não define um marcador de posição de cabeçalho para slides regulares. Em slides regulares, use os marcadores de posição de rodapé, data/hora e número de slide. Os marcadores de cabeçalho estão disponíveis nas páginas de notas e nos folhetos.

**E se um marcador de posição de rodapé, data/hora ou número de slide não estiver visível?**

Use o gerenciador de cabeçalho/rodapé correspondente para verificar sua visibilidade e habilitá-lo quando necessário. Por exemplo, [isFooterVisible](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) indica se um marcador de posição de rodapé está presente, e [setFooterVisibility](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) altera sua visibilidade.

**Como iniciar a numeração de slides a partir de um valor diferente de 1?**

Chame o método [setFirstSlideNumber](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#setFirstSlideNumber) da apresentação. Os marcadores de número de slide então usarão a sequência de numeração atualizada.

**O que acontece com cabeçalhos e rodapés ao exportar para PDF, imagens ou HTML?**

Os elementos de cabeçalho e rodapé visíveis são renderizados junto com o restante do conteúdo da apresentação no formato de saída. Sua aparência depende do tipo de página que está sendo exportado e das configurações de visibilidade dos marcadores de posição correspondentes.