---
title: Gerenciar cabeçalhos e rodapés da apresentação em Java
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
description: "Use Aspose.Slides for Java para adicionar e personalizar cabeçalhos e rodapés em apresentações PowerPoint e OpenDocument para uma aparência profissional."
---
## **Visão geral**

Aspose.Slides permite gerenciar as configurações de cabeçalho e rodapé em apresentações do PowerPoint. Cabeçalhos e rodapés são manipulados no nível do mestre da apresentação, e a API fornece métodos para definir o texto do rodapé, alterar a visibilidade do rodapé e atualizar o texto do cabeçalho nos slides mestres de notas.

Você também pode gerenciar cabeçalhos e rodapés para folhetos e slides de notas. Isso inclui alterar a visibilidade e o texto dos marcadores de posição de cabeçalho, rodapé, número do slide e data/hora no mestre de notas, em todos os slides de notas filhos ou em um slide de notas individual.

## **Gerenciar cabeçalhos e rodapés em uma apresentação**
As notas de um slide específico podem ser removidas, conforme mostrado no exemplo abaixo:

```java
// Carregar apresentação
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Definir rodapé
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Acessar e atualizar cabeçalho
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Salvar apresentação
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Método para definir o texto do Cabeçalho/Rodapé
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Gerenciar cabeçalhos e rodapés em Folhetos e Slides de Notas**
Aspose.Slides for Java suporta Header e Footer em folhetos e slides de notas. Siga os passos abaixo:

- Carregue uma [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation) que contenha um vídeo.
- Altere as configurações de Header e Footer para o mestre de notas e todos os slides de notas.
- Defina como visíveis os marcadores de posição de Footer no slide mestre de notas e em todos os filhos.
- Defina como visíveis os marcadores de posição de Date e time no slide mestre de notas e em todos os filhos.
- Altere as configurações de Header e Footer apenas para o primeiro slide de notas.
- Defina o marcador de posição de Header do slide de notas como visível.
- Defina o texto no marcador de posição de Header do slide de notas.
- Defina o texto no marcador de posição de Date-time do slide de notas.
- Grave o arquivo de apresentação modificado.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Alterar configurações de Cabeçalho e Rodapé para o mestre de notas e todos os slides de notas
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de Rodapé filhos visíveis
        headerFooterManager.setFooterAndChildFootersVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de Cabeçalho filhos visíveis
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de Número do Slide filhos visíveis
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // torna o slide mestre de notas e todos os marcadores de posição de Data e hora filhos visíveis

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // define o texto no slide mestre de notas e em todos os marcadores de posição de Cabeçalho filhos
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // define o texto no slide mestre de notas e em todos os marcadores de posição de Rodapé filhos
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // define o texto no slide mestre de notas e em todos os marcadores de posição de Data e hora filhos
    }

    // Alterar configurações de Cabeçalho e Rodapé apenas para o primeiro slide de notas
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // torna este marcador de posição de Cabeçalho do slide de notas visível

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // torna este marcador de posição de Rodapé do slide de notas visível

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // torna este marcador de posição de Número do Slide do slide de notas visível

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // torna este marcador de posição de Data e hora do slide de notas visível

        headerFooterManager.setHeaderText("New header text"); // define o texto no marcador de posição de Cabeçalho do slide de notas
        headerFooterManager.setFooterText("New footer text"); // define o texto no marcador de posição de Rodapé do slide de notas
        headerFooterManager.setDateTimeText("New date and time text"); // define o texto no marcador de posição de Data e hora do slide de notas
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Posso adicionar um "header" aos slides normais?**

No PowerPoint, "Header" existe apenas para notas e folhetos; nos slides normais, os elementos suportados são o Footer, Date/Time e SlideNumber. No Aspose.Slides isso corresponde às mesmas limitações: Header apenas para Notes/Handout, e nos slides — Footer/DateTime/SlideNumber.

**E se o layout não contiver uma área de rodapé—posso "ativar" sua visibilidade?**

Sim. Verifique a visibilidade através do gerenciador de header/footer e habilite‑a se necessário. Esses indicadores e métodos da API foram projetados para casos em que o marcador de posição está ausente ou oculto.

**Como faço para que o número do slide comece a partir de um valor diferente de 1?**

Defina o [first slide number](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) da apresentação; após isso, toda a numeração é recalculada. Por exemplo, você pode iniciar em 0 ou 10 e ocultar o número no slide de título.

**O que acontece com cabeçalhos/rodapés ao exportar para PDF/imagens/HTML?**

Eles são renderizados como elementos de texto normais da apresentação. Ou seja, se os elementos estiverem visíveis nas páginas de slides/notas, também aparecerão no formato de saída juntamente com o restante do conteúdo.