---
title: Konwertowanie prezentacji PowerPoint na animowane GIFy w JavaScript
linktitle: PowerPoint na GIF
type: docs
weight: 65
url: /pl/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- animowany GIF
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na GIF
- prezentacja na GIF
- slajd na GIF
- PPT na GIF
- PPTX na GIF
- zapisz PPT jako GIF
- zapisz PPTX jako GIF
- eksportuj PPT jako GIF
- eksportuj PPTX jako GIF
- ustawienia domyślne
- ustawienia niestandardowe
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIFy w JavaScript przy użyciu Aspose.Slides dla Node.js poprzez Java. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do animowanych plików GIF za pomocą kilku wierszy kodu. Jest to przydatne, gdy trzeba udostępnić zawartość slajdów w lekkim, powszechnie obsługiwanym formacie animowanym, który można osadzić w stronach internetowych, komunikatorach lub dokumentacji. W tym artykule wyjaśniono, jak wyeksportować prezentację do formatu GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurować opcje takie jak rozmiar klatki, opóźnienie slajdu i częstotliwość klatek przejścia za pomocą [GifOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/gifoptions/).

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień domyślnych**

Ten przykładowy kod w JavaScript pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu standardowych ustawień:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Animowany GIF zostanie utworzony z parametrami domyślnymi. 

{{%  alert  title="Wskazówka"  color="primary"  %}} 
Jeśli chcesz dostosować parametry GIF, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GifOptions). Zobacz przykładowy kod poniżej.
{{% /alert %}} 

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień niestandardowych**

Ten przykładowy kod pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu własnych ustawień w JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// rozmiar wynikowego GIFa
    gifOptions.setDefaultDelay(2000);// jak długo każdy slajd będzie wyświetlany, zanim zostanie zmieniony na kolejny
    gifOptions.setTransitionFps(35);// zwiększ FPS, aby poprawić jakość animacji przejścia
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
Możesz wypróbować bezpłatny konwerter [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowany przez Aspose. 
{{% /alert %}}

## **FAQ**

**Co zrobić, jeśli czcionki użyte w prezentacji nie są zainstalowane w systemie?**

Zainstaluj brakujące czcionki lub [skonfiguruj czcionki awaryjne](/slides/pl/nodejs-java/powerpoint-fonts/). Aspose.Slides podstawi zastępcze, ale wygląd może się różnić. Dla zachowania marki zawsze upewnij się, że wymagane kroje są dostępne.

**Czy mogę nałożyć znak wodny na klatki GIF?**

Tak. [Dodaj półprzezroczysty obiekt/logo](/slides/pl/nodejs-java/watermark/) do głównego slajdu lub do poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.