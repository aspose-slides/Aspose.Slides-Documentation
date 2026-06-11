---
title: Konwertuj prezentacje PowerPoint na animowane GIFy w systemie Android
linktitle: PowerPoint na GIF
type: docs
weight: 65
url: /pl/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIFy przy użyciu Aspose.Slides dla Androida w Javie. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint na animowane pliki GIF przy użyciu zaledwie kilku wierszy kodu. Jest to przydatne, gdy trzeba udostępnić zawartość slajdów w lekkim, szeroko wspieranym formacie animacji, który można osadzić w stronach internetowych, komunikatorach lub dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację do GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurując opcje takie jak rozmiar klatki, opóźnienie slajdu i częstotliwość przejść za pomocą [GifOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/gifoptions/).

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień domyślnych**

Poniższy przykładowy kod w języku Java pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu standardowych ustawień:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Animowany GIF zostanie utworzony z parametrami domyślnymi. 

{{%  alert  title="Wskazówka"  color="primary"  %}} 

Jeśli chcesz dostosować parametry GIF‑a, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GifOptions). Zobacz przykładowy kod poniżej.

{{% /alert %}} 

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień niestandardowych**

Poniższy przykładowy kod pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu własnych ustawień w języku Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // rozmiar wygenerowanego GIF-a  
	gifOptions.setDefaultDelay(2000); // jak długo każdy slajd będzie wyświetlany, zanim przejdzie do następnego
	gifOptions.setTransitionFps(35); // zwiększ FPS, aby poprawić jakość animacji przejścia
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Informacja" color="info" %}}

Możesz wypróbować DARMOWY [Tekst na GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowany przez Aspose. 

{{% /alert %}}

## **FAQ**

**Co zrobić, jeśli czcionki użyte w prezentacji nie są zainstalowane w systemie?**

Zainstaluj brakujące czcionki lub [konfigurować czcionki zastępcze](/slides/pl/androidjava/powerpoint-fonts/). Aspose.Slides zastąpi brakujące czcionki, ale wygląd może się różnić. Dla zachowania spójności marki zawsze upewnij się, że wymagane rodziny czcionek są dostępne.

**Czy mogę dodać znak wodny na klatki GIF?**

Tak. [Dodaj półprzezroczysty obiekt/logo](/slides/pl/androidjava/watermark/) do szablonu master lub do poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.