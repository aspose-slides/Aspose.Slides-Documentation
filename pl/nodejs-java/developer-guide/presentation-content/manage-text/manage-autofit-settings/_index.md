---
title: Ulepsz swoje prezentacje przy użyciu AutoFit w JavaScript
linktitle: Ustawienia AutoFit
type: docs
weight: 30
url: /pl/nodejs-java/manage-autofit-settings/
keywords:
- pole tekstowe
- autofit
- nie używaj autofitu
- dopasuj tekst
- zmniejsz tekst
- zawijaj tekst
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj ustawieniami AutoFit w Aspose.Slides dla Node.js, aby zoptymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Wprowadzenie**

Domyślnie, gdy dodajesz pole tekstowe, Microsoft PowerPoint używa ustawienia **Resize shape to fix text** dla pola tekstowego — automatycznie zmienia rozmiar pola tekstowego, aby zapewnić, że jego tekst zawsze mieści się w nim. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Gdy tekst w polu tekstowym staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole tekstowe — zwiększa jego wysokość — aby pomieścić więcej tekstu. 
* Gdy tekst w polu tekstowym staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole tekstowe — zmniejsza jego wysokość — aby usunąć zbędną przestrzeń. 

W programie PowerPoint są to 4 ważne parametry lub opcje kontrolujące zachowanie autofitu dla pola tekstowego: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java udostępnia podobne opcje — niektóre właściwości klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat) — które umożliwiają kontrolowanie zachowania autofitu dla pól tekstowych w prezentacjach.

## **Zmienianie rozmiaru kształtu, aby dopasować tekst**

Jeśli chcesz, aby tekst w ramce zawsze mieścił się w tej ramce po wprowadzeniu zmian, musisz użyć opcji **Resize shape to fix text**. Aby określić to ustawienie, wywołaj metodę [setAutofitType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat) z wartością `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ten kod JavaScript pokazuje, jak określić, że tekst musi zawsze mieścić się w swojej ramce w prezentacji PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Jeśli tekst stanie się dłuższy lub większy, pole tekstowe zostanie automatycznie zmienione rozmiarowo (zwiększy wysokość), aby cały tekst się w nim zmieścił. Jeśli tekst stanie się krótszy, nastąpi odwrotne działanie. 

## **Nie stosuj AutoFit**

Jeśli chcesz, aby pole tekstowe lub kształt zachowały swoje wymiary niezależnie od zmian wprowadzonych w zawartym tekście, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, wywołaj metodę [setAutofitType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat) z wartością `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ten kod JavaScript pokazuje, jak określić, że pole tekstowe musi zawsze zachowywać swoje wymiary w prezentacji PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Gdy tekst stanie się zbyt długi dla swojej ramki, wycieka poza nią. 

## **Zmniejsz tekst przy przepełnieniu**

Jeśli tekst staje się zbyt długi dla swojej ramki, przy użyciu opcji **Shrink text on overflow** możesz określić, że rozmiar i odstępy tekstu mają zostać zmniejszone, aby zmieścił się w ramce. Aby określić to ustawienie, wywołaj metodę [setAutofitType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat) z wartością `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod JavaScript pokazuje, jak określić, że tekst ma być zmniejszany przy przepełnieniu w prezentacji PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Kiedy użyta jest opcja **Shrink text on overflow**, ustawienie jest stosowane tylko wtedy, gdy tekst stanie się zbyt długi dla swojej ramki. 
{{% /alert %}}

## **Wrap Text**

Jeśli chcesz, aby tekst w kształcie był zawijany wewnątrz tego kształtu, gdy tekst wychodzi poza jego obramowanie (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, należy wywołać metodę [setWrapText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat) z wartością `true`.

Ten kod JavaScript pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
Jeśli wywołasz metodę `setWrapText` z wartością `False` dla kształtu, gdy tekst wewnątrz kształtu stanie się dłuższy niż szerokość kształtu, tekst zostanie wydłużony poza obramowania kształtu w jednej linii. 
{{% /alert %}}

## **FAQ**

**Czy wewnętrzne marginesy ramki tekstowej wpływają na AutoFit?**

Tak. Wypełnienie (marginesy wewnętrzne) zmniejsza dostępną powierzchnię dla tekstu, więc AutoFit uruchomi się wcześniej — zmniejszając czcionkę lub zmieniając rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed regulacją AutoFit.

**Jak AutoFit współdziała z ręcznymi i miękkimi podziałami wierszy?**

Wymuszone podziały pozostają na miejscu, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usunięcie niepotrzebnych podziałów często zmniejsza agresywność, z jaką AutoFit musi zmniejszyć tekst.

**Czy zmiana czcionki motywu lub wywołanie podstawienia czcionki wpływa na wyniki AutoFit?**

Tak. Zastąpienie czcionki czcionką o innych metrykach glifów zmienia szerokość/wysokość tekstu, co może zmienić ostateczny rozmiar czcionki i zawijanie linii. Po każdej zmianie czcionki lub jej podstawieniu należy ponownie sprawdzić slajdy.