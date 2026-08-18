---
title: Gerenciar cabeçalhos e rodapés de apresentação em Java
linktitle: Cabeçalho e Rodapé
type: docs
weight: 140
url: /pt/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Aprenda como gerenciar marcadores de posição de rodapé, data/hora, número do slide e cabeçalho em slides, páginas de notas e folhetos com Aspose.Slides para Java."
---
## **Visão geral**

O PowerPoint usa diferentes marcadores de posição de cabeçalho e rodapé dependendo do tipo de página. O Aspose.Slides for Java permite controlar o texto e a visibilidade desses marcadores de posição por meio de interfaces de gerenciador de cabeçalho/rodapé.

Os marcadores de posição disponíveis dependem do escopo:

| Escopo | Cabeçalho | Rodapé | Data/hora | Número do slide/página |
|---|---|---|---|---|
| Slide regular | Não | Sim | Sim | Sim |
| Mestre de notas | Sim | Sim | Sim | Sim |
| Slide de notas | Sim | Sim | Sim | Sim |
| Mestre de folheto | Sim | Sim | Sim | Sim |

Um slide de apresentação regular não tem um marcador de posição de cabeçalho. Os cabeçalhos estão disponíveis em páginas de notas e folhetos. Para slides regulares, use os marcadores de posição de rodapé, data/hora e número do slide.

O escopo de uma alteração depende do gerenciador que você usa. A interface [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islideheaderfootermanager/) controla um slide regular. A interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/inotesslideheaderfootermanager/) controla um slide de notas. Gerenciadores de mestre e layout também podem propagar configurações para slides dependentes, enquanto a interface [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) controla o mestre de folhetos.

## **Definir Rodapé, Data/Hora e Números de Slide em Slides Regulares**

Para slides regulares, o fluxo básico é acessar o gerenciador de cabeçalho/rodapé de cada slide, definir o texto do rodapé e da data/hora, habilitar os marcadores de posição necessários e salvar a apresentação. Os números de slide são gerados pela apresentação, portanto você só precisa controlar sua visibilidade.

Use [`setFooterText`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) e [`setDateTimeText`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) para definir texto, e use [`setFooterVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), e [`setSlideNumberVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) para mostrar os marcadores de posição correspondentes.

O exemplo a seguir aplica o mesmo rodapé, texto de data/hora e visibilidade de número de slide a todos os slides regulares:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se precisar atualizar apenas um slide, acesse esse slide diretamente através do método [`getSlides`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#getSlides--) em vez de percorrer toda a coleção.

## **Definir Cabeçalhos e Rodapés no Mestre de Notas**

O mestre de notas define formatação comum e comportamento dos marcadores de posição para páginas de notas. Use a interface [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/) quando desejar alterar apenas o próprio mestre de notas.

O exemplo a seguir define texto de cabeçalho, rodapé e data/hora no mestre de notas e torna todos os marcadores de posição suportados visíveis nesse mestre:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O método [`getMasterNotesSlide`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) retorna `null` quando a apresentação não contém um mestre de notas.

## **Aplicar Configurações do Mestre de Notas aos Slides de Notas Filhos**

Um mestre de notas pode aplicar configurações de cabeçalho e rodapé a ele próprio e a todos os slides de notas dependentes. Use os métodos de propagação dedicados em [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/) quando as mesmas configurações devem ser aplicadas em toda a hierarquia de notas.

Por exemplo, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) e [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) atualizam o cabeçalho do mestre de notas e todos os cabeçalhos filhos. Métodos equivalentes estão disponíveis para rodapés, data/hora e números de slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Os métodos de propagação usados acima são [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), e [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Definir Cabeçalhos e Rodapés em um Slide de Notas Individual**

Um slide de notas pertence a um slide regular específico. Use a interface [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/inotesslideheaderfootermanager/) quando quiser personalizar apenas essa página de notas.

O método [`addNotesSlide`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) retorna o slide de notas para o slide atual e cria um caso ainda não exista. O exemplo a seguir configura a página de notas associada ao primeiro slide da apresentação:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Se primeiro propagar as configurações do mestre de notas e depois alterar um slide de notas individual, as configurações posteriores por slide permitem personalizar essa página de notas de forma independente.

## **Definir Cabeçalhos e Rodapés no Mestre de Folhetos**

As páginas de folhetos utilizam o mestre de folhetos para seus marcadores de posição de cabeçalho, rodapé, data/hora e número de página. Ao contrário das páginas de notas, as configurações de folhetos são gerenciadas através do mestre de folhetos em vez de slides individuais de folhetos.

Use o método [`getMasterHandoutSlide`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) para acessar o mestre de folhetos. Se ele não estiver presente, chame [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) para criar o mestre de folhetos padrão.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Entender Escopo e Herança**

Escolha o gerenciador de cabeçalho/rodapé que corresponde ao escopo que você deseja alterar:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/islideheaderfootermanager/) altera as configurações de rodapé, data/hora e número do slide para um slide regular.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilayoutslideheaderfootermanager/) controla um slide de layout e pode propagar as configurações suportadas para slides dependentes.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterslideheaderfootermanager/) controla um mestre de slide regular e pode propagar as configurações suportadas para slides dependentes.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasternotesslideheaderfootermanager/) controla o mestre de notas e pode propagar as configurações para todos os slides de notas dependentes.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/inotesslideheaderfootermanager/) altera um slide de notas e suporta um marcador de posição de cabeçalho além de rodapé, data/hora e número do slide.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) altera o mestre de folhetos e suporta os quatro tipos de marcadores de posição.

Use a propagação a partir de um mestre ou layout quando a mesma configuração deva ser aplicada em toda a sua hierarquia. Use um slide individual ou o gerenciador de slide de notas quando precisar de uma configuração local para uma única página.

## **FAQ**

**Posso adicionar um cabeçalho a um slide regular?**

Não. O PowerPoint não define um marcador de posição de cabeçalho para slides regulares. Em slides regulares, use os marcadores de posição de rodapé, data/hora e número do slide. Os marcadores de posição de cabeçalho estão disponíveis em páginas de notas e folhetos.

**E se um marcador de posição de rodapé, data/hora ou número do slide não estiver visível?**

Use o gerenciador de cabeçalho/rodapé correspondente para verificar sua visibilidade e habilitá-lo quando necessário. Por exemplo, [`isFooterVisible`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) informa se um marcador de posição de rodapé está presente, e [`setFooterVisibility`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) altera sua visibilidade.

**Como iniciar a numeração de slides a partir de um valor diferente de 1?**

Chame o método [`setFirstSlideNumber`](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) da apresentação. Os marcadores de posição de número do slide então usarão a sequência de numeração atualizada.

**O que acontece com cabeçalhos e rodapés ao exportar para PDF, imagens ou HTML?**

Os elementos visíveis de cabeçalho e rodapé são renderizados junto com o restante do conteúdo da apresentação no formato de saída. Sua aparência depende do tipo de página que está sendo exportado e das configurações de visibilidade dos marcadores de posição correspondentes.