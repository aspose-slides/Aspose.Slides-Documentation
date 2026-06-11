---
title: Ulepsz swoje prezentacje dzięki AutoFit w Javie
linktitle: Ustawienia Autofit
type: docs
weight: 30
url: /pl/java/manage-autofit-settings/
keywords:
- pole tekstowe
- autofit
- nie dopasowuj automatycznie
- dopasuj tekst
- zmniejsz tekst
- zawijaj tekst
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać ustawieniami AutoFit w Aspose.Slides dla Javy, aby zoptymalizować wyświetlanie tekstu w prezentacjach PowerPoint i OpenDocument oraz poprawić czytelność treści."
---
## **Introduction**

Domyślnie, gdy dodajesz pole tekstowe, Microsoft PowerPoint używa ustawienia **Resize shape to fix text** dla pola tekstowego — automatycznie zmienia rozmiar pola tekstowego, aby jego tekst zawsze w niego pasował. 

![pole tekstowe w PowerPoint](textbox-in-powerpoint.png)

* Gdy tekst w polu tekstowym staje się dłuższy lub większy, PowerPoint automatycznie powiększa pole tekstowe — zwiększa jego wysokość — aby pomieścić więcej tekstu. 
* Gdy tekst w polu tekstowym staje się krótszy lub mniejszy, PowerPoint automatycznie zmniejsza pole tekstowe — zmniejsza jego wysokość — aby usunąć zbędną przestrzeń. 

W PowerPoint istnieją 4 ważne parametry lub opcje kontrolujące zachowanie autofit dla pola tekstowego: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![opcje autofit w PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Java udostępnia podobne opcje — niektóre właściwości w klasie [TextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat) — które pozwalają kontrolować zachowanie autofit dla pól tekstowych w prezentacjach. 

## **Resize a Shape to Fit Text**

Jeśli chcesz, aby tekst w polu zawsze pasował do tego pola po wprowadzeniu zmian, musisz użyć opcji **Resize shape to fix text**. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat)) na `Shape`.

![ustawienie zawsze dopasowuj w PowerPoint](alwaysfit-setting-powerpoint.png)

Ten kod Java pokazuje, jak określić, że tekst musi zawsze pasować do swojego pola w prezentacji PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Jeśli tekst stanie się dłuższy lub większy, pole tekstowe zostanie automatycznie powiększone (wzrośnie wysokość), aby zapewnić, że cały tekst w nim zmieści się. Jeśli tekst stanie się krótszy, nastąpi odwrotna operacja. 

## **Do Not Autofit**

Jeśli chcesz, aby pole tekstowe lub kształt zachowały swoje wymiary niezależnie od zmian w zawartym tekście, musisz użyć opcji **Do not Autofit**. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat)) na `None`. 

![ustawienie nie dopasuj w PowerPoint](donotautofit-setting-powerpoint.png)

Ten kod Java pokazuje, jak określić, że pole tekstowe zawsze zachowa swoje wymiary w prezentacji PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Gdy tekst stanie się zbyt długi dla swojego pola, wycieka poza nie. 

## **Shrink Text on Overflow**

Jeśli tekst stanie się zbyt długi dla swojego pola, dzięki opcji **Shrink text on overflow** możesz określić, że rozmiar i odstępy tekstu zostaną zmniejszone, aby zmieścił się w polu. Aby określić to ustawienie, ustaw właściwość [AutofitType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat)) na `Normal`.

![ustawienie zmniejsz tekst przy przepełnieniu w PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Ten kod Java pokazuje, jak określić, że tekst ma być zmniejszany przy przepełnieniu w prezentacji PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Gdy użyta zostanie opcja **Shrink text on overflow**, ustawienie jest stosowane tylko wtedy, gdy tekst staje się zbyt długi dla swojego pola. 
{{% /alert %}}

## **Wrap Text**

Jeśli chcesz, aby tekst w kształcie był zawijany wewnątrz tego kształtu, gdy przekracza on jego granicę (tylko szerokość), musisz użyć parametru **Wrap text in shape**. Aby określić to ustawienie, ustaw właściwość [WrapText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat#getWrapText--) (z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat)) na `true`. 

Ten kod Java pokazuje, jak używać ustawienia Wrap Text w prezentacji PowerPoint:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Jeśli ustawisz właściwość `WrapText` na `False` dla kształtu, gdy tekst wewnątrz kształtu stanie się dłuższy niż jego szerokość, tekst będzie się rozciągał poza granice kształtu w jednej linii. 
{{% /alert %}}

## **FAQ**

**Do the text frame’s internal margins affect AutoFit?**  
**Czy wewnętrzne marginesy ramki tekstu wpływają na AutoFit?**

Tak. Padding (wewnętrzne marginesy) zmniejsza dostępny obszar dla tekstu, więc AutoFit uruchamia się wcześniej — zmniejszając czcionkę lub zmieniając rozmiar kształtu szybciej. Sprawdź i dostosuj marginesy przed regulacją AutoFit.

**How does AutoFit interact with manual and soft line breaks?**  
**Jak AutoFit współdziała z ręcznymi i miękkimi podziałami linii?**

Wymuszone podziały pozostają, a AutoFit dostosowuje rozmiar czcionki i odstępy wokół nich. Usunięcie niepotrzebnych podziałów często zmniejsza agresywność, z jaką AutoFit musi zmniejszać tekst.

**Does changing the theme font or triggering font substitution affect AutoFit results?**  
**Czy zmiana czcionki motywu lub wywołanie substytucji czcionki wpływa na wyniki AutoFit?**

Tak. Zastąpienie czcionki inną o innych metrykach glyfów zmienia szerokość/wysokość tekstu, co może zmienić końcowy rozmiar czcionki i zawijanie linii. Po każdej zmianie czcionki lub substytucji ponownie sprawdź slajdy.