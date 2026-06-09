---
title: Gerenciar Cabeçalhos e Rodapés de Apresentação no Android
linktitle: Cabeçalho & Rodapé
type: docs
weight: 140
url: /pt/androidjava/presentation-header-and-footer/
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
- Android
- Java
- Aspose.Slides
description: "Use Aspose.Slides for Android via Java para adicionar e personalizar cabeçalhos e rodapés em apresentações PowerPoint e OpenDocument, proporcionando um visual profissional."
---
## **Visão geral**

Aspose.Slides permite que você gerencie as configurações de cabeçalho e rodapé em apresentações do PowerPoint. Cabeçalhos e rodapés são manipulados no nível do mestre da apresentação, e a API fornece métodos para definir o texto do rodapé, alterar a visibilidade do rodapé e atualizar o texto do cabeçalho nos slides mestre de notas.

Você também pode gerenciar cabeçalhos e rodapés para os slides de folheto e notas. Isso inclui alterar a visibilidade e o texto dos marcadores de posição de cabeçalho, rodapé, número do slide e data/hora para o mestre de notas, todos os slides de notas filho ou um slide de notas individual.

## **Gerenciar Cabeçalhos e Rodapés em uma Apresentação**
As notas de um slide específico podem ser removidas como mostrado no exemplo abaixo:

```java
// Carregar apresentação
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Definindo rodapé
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

## **Gerenciar Cabeçalhos e Rodapés em Slides de Folheto e Notas**
Aspose.Slides for Android via Java oferece suporte a Cabeçalho e Rodapé em slides de Folheto e notas. Siga os passos abaixo:

- Carregue uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/Presentation) que contenha um vídeo.
- Altere as configurações de Cabeçalho e Rodapé para o mestre de notas e todos os slides de notas.
- Defina o slide mestre de notas e todos os marcadores de posição de Rodapé filho como visíveis.
- Defina o slide mestre de notas e todos os marcadores de posição de Data e hora filho como visíveis.
- Altere as configurações de Cabeçalho e Rodapé apenas para o primeiro slide de notas.
- Defina o marcador de posição de Cabeçalho do slide de notas como visível.
- Defina o texto no marcador de posição de Cabeçalho do slide de notas.
- Defina o texto no marcador de posição de Data-hora do slide de notas.
- Grave o arquivo de apresentação modificado.

O trecho de código é fornecido no exemplo abaixo.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Alterar as configurações de Cabeçalho e Rodapé para o mestre de notas e todos os slides de notas
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // tornar o slide mestre de notas e todos os marcadores de posição de Rodapé filhos visíveis
        headerFooterManager.setFooterAndChildFootersVisibility(true); // tornar o slide mestre de notas e todos os marcadores de posição de Cabeçalho filhos visíveis
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // tornar o slide mestre de notas e todos os marcadores de posição de Número do Slide filhos visíveis
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // tornar o slide mestre de notas e todos os marcadores de posição de Data e hora filhos visíveis

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // definir texto para o slide mestre de notas e todos os marcadores de posição de Cabeçalho filhos
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // definir texto para o slide mestre de notas e todos os marcadores de posição de Rodapé filhos
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // definir texto para o slide mestre de notas e todos os marcadores de posição de Data e hora filhos
    }

    // Alterar as configurações de Cabeçalho e Rodapé apenas para o primeiro slide de notas
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // tornar este marcador de posição de Cabeçalho do slide de notas visível

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // tornar este marcador de posição de Rodapé do slide de notas visível

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // tornar este marcador de posição de Número do Slide do slide de notas visível

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // tornar este marcador de posição de Data-hora do slide de notas visível

        headerFooterManager.setHeaderText("New header text"); // definir texto para o marcador de posição de Cabeçalho do slide de notas
        headerFooterManager.setFooterText("New footer text"); // definir texto para o marcador de posição de Rodapé do slide de notas
        headerFooterManager.setDateTimeText("New date and time text"); // definir texto para o marcador de posição de Data-hora do slide de notas
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Perguntas Frequentes**

**Posso adicionar um "cabeçalho" aos slides normais?**

No PowerPoint, o "Header" existe apenas para notas e folhetos; em slides normais, os elementos suportados são o rodapé, data/hora e número do slide. No Aspose.Slides isso corresponde às mesmas limitações: cabeçalho apenas para Notas/Folhetos, e nos slides — Rodapé/DataHora/Número do Slide.

**E se o layout não contiver uma área de rodapé—posso "ativar" sua visibilidade?**

Sim. Verifique a visibilidade via o gerenciador de cabeçalho/rodapé e habilite-a se necessário. Esses indicadores e métodos da API foram projetados para casos em que o marcador de posição está ausente ou oculto.

**Como faço para que o número do slide comece a partir de um valor diferente de 1?**

Defina o [first slide number](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) da apresentação; após isso, toda a numeração é recalculada. Por exemplo, você pode iniciar em 0 ou 10, e ocultar o número no slide de título.

**O que acontece com cabeçalhos/rodapés ao exportar para PDF/imagens/HTML?**

Eles são renderizados como elementos de texto normais da apresentação. Ou seja, se os elementos estiverem visíveis nos slides/páginas de notas, também aparecerão no formato de saída juntamente com o restante do conteúdo.