---
title: Gerenciar cabeçalhos e rodapés de apresentação em JavaScript
linktitle: Cabeçalho & Rodapé
type: docs
weight: 140
url: /pt/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Use JavaScript e Aspose.Slides para Node.js para adicionar e personalizar cabeçalhos e rodapés em apresentações PowerPoint e OpenDocument, proporcionando um visual profissional."
---
## **Visão geral**

Aspose.Slides permite que você gerencie as configurações de cabeçalho e rodapé em apresentações do PowerPoint. Cabeçalhos e rodapés são tratados no nível do mestre da apresentação, e a API fornece métodos para definir o texto do rodapé, alterar a visibilidade do rodapé e atualizar o texto do cabeçalho nos slides mestres de notas.

Você também pode gerenciar cabeçalhos e rodapés para slides de folheto e notas. Isso inclui alterar a visibilidade e o texto dos espaços reservados de cabeçalho, rodapé, número de slide e data/hora para o mestre de notas, todos os slides de notas filhos ou um slide de notas individual.

## **Gerenciar cabeçalho e rodapé na apresentação**
As notas de alguns slides específicos podem ser removidas, conforme mostrado no exemplo abaixo:

```javascript
// Carregar apresentação
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Definindo rodapé
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Acessar e atualizar cabeçalho
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Salvar apresentação
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Gerenciar cabeçalho e rodapé em slides de folheto e notas**
Aspose.Slides para Node.js via Java oferece suporte a Header e Footer em slides de folheto e notas. Siga os passos abaixo:

- Carregue uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation) contendo um vídeo.
- Altere as configurações de Header e Footer para o mestre de notas e todos os slides de notas.
- Defina o slide mestre de notas e todos os espaços reservados de Footer filhos como visíveis.
- Defina o slide mestre de notas e todos os espaços reservados de Date and time filhos como visíveis.
- Altere as configurações de Header e Footer apenas para o primeiro slide de notas.
- Defina o espaço reservado de Header do slide de notas como visível.
- Defina o texto no espaço reservado de Header do slide de notas.
- Defina o texto no espaço reservado de Date-time do slide de notas.
- Grave o arquivo de apresentação modificado.

Trecho de código fornecido no exemplo abaixo.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Alterar configurações de Cabeçalho e Rodapé para o mestre de notas e todos os slides de notas
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de Rodapé filhos visíveis
        headerFooterManager.setFooterAndChildFootersVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de Cabeçalho filhos visíveis
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de Número de slide filhos visíveis
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// torna o slide mestre de notas e todos os marcadores de posição de Data e hora filhos visíveis
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// define o texto no slide mestre de notas e em todos os marcadores de posição de Cabeçalho filhos
        headerFooterManager.setFooterAndChildFootersText("Footer text");// define o texto no slide mestre de notas e em todos os marcadores de posição de Rodapé filhos
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// define o texto no slide mestre de notas e em todos os marcadores de posição de Data e hora filhos
    }
    // Alterar configurações de Cabeçalho e Rodapé apenas para o primeiro slide de notas
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// torna este marcador de posição de Cabeçalho do slide de notas visível
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// torna este marcador de posição de Rodapé do slide de notas visível
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// torna este marcador de posição de Número de slide do slide de notas visível
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// torna este marcador de posição de Data e hora do slide de notas visível
        headerFooterManager.setHeaderText("New header text");// define o texto no marcador de posição de Cabeçalho do slide de notas
        headerFooterManager.setFooterText("New footer text");// define o texto no marcador de posição de Rodapé do slide de notas
        headerFooterManager.setDateTimeText("New date and time text");// define o texto no marcador de posição de Data e hora do slide de notas
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso adicionar um "header" a slides normais?**

No PowerPoint, “Header” existe apenas para notes e handouts; em slides normais, os elementos suportados são o Footer, date/time e slide number. No Aspose.Slides isso corresponde às mesmas limitações: header apenas para Notes/Handout, e nos slides — Footer/DateTime/SlideNumber.

**E se o layout não contiver uma área de footer—posso “ativar” sua visibilidade?**

Sim. Verifique a visibilidade através do gerenciador de header/footer e habilite-a, se necessário. Esses indicadores e métodos da API foram projetados para casos em que o placeholder está ausente ou oculto.

**Como faço o slide number começar a partir de um valor diferente de 1?**

Defina o [first slide number](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/setfirstslidenumber/); depois disso, toda a numeração é recalculada. Por exemplo, você pode iniciar em 0 ou 10 e ocultar o número no slide de título.

**O que acontece com headers/footers ao exportar para PDF/images/HTML?**

Eles são renderizados como elementos de texto normais da apresentação. Ou seja, se os elementos estiverem visíveis nas páginas de slides/notes, eles também aparecerão no formato de saída junto com o restante do conteúdo.