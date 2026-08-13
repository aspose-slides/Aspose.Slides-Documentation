---
title: Konwertuj prezentacje PowerPoint na animowane GIF-y na Androidzie
linktitle: PowerPoint do GIF
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
- PowerPoint do GIF
- prezentacja do GIF
- slajd do GIF
- PPT do GIF
- PPTX do GIF
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
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) na animowane GIF-y przy użyciu Aspose.Slides dla Androida w Javie. Szybkie, wysokiej jakości rezultaty."
---
## **Przegląd**

Aspose.Slides pozwala konwertować prezentacje PowerPoint na animowane pliki GIF przy użyciu kilku linii kodu. Jest to przydatne, gdy musisz udostępnić zawartość slajdów w lekkim, szeroko obsługiwanym formacie animowanym, który można osadzić w stronach internetowych, komunikatorach lub dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację do formatu GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurując opcje takie jak rozmiar klatki, opóźnienie slajdu i szybkość klatek przejścia za pomocą [GifOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/gifoptions/).

## **Konwertowanie prezentacji na animowany GIF przy użyciu ustawień domyślnych**

Poniższy przykładowy kod w języku Java pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu standardowych ustawień:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.gif", SaveFormat.Gif);
} finally {
    if (pres != null) pres.dispose();
}
```

Animowany GIF zostanie utworzony z parametrami domyślnymi.

{{%  alert  title="TIP"  color="info"  %}} 
Jeśli wolisz dostosować parametry GIF‑a, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/GifOptions). Zobacz poniższy przykładowy kod. 
{{% /alert %}} 

## **Konwertowanie prezentacji na animowany GIF przy użyciu niestandardowych ustawień**

Poniższy przykładowy kod pokazuje, jak przekonwertować prezentację na animowany GIF przy użyciu niestandardowych ustawień w języku Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // rozmiar wygenerowanego GIF-a
	gifOptions.setDefaultDelay(2000); // jak długo każdy slajd będzie wyświetlany, zanim zostanie zmieniony na kolejny
	gifOptions.setTransitionFps(35); // zwiększ FPS, aby poprawić jakość animacji przejścia
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Możesz zainteresować się darmowym konwerterem [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowanym przez Aspose. 
{{% /alert %}}

## **FAQ**

### Co zrobić, jeśli czcionki użyte w prezentacji nie są zainstalowane w systemie?

Zainstaluj brakujące czcionki lub [skonfiguruj czcionki zapasowe](/slides/pl/androidjava/powerpoint-fonts/). Aspose.Slides zastosuje zamienniki, ale wygląd może się różnić. Dla zachowania identyfikacji wizualnej zawsze upewnij się, że wymagane kroje pisma są wyraźnie dostępne.

### Czy mogę nałożyć znak wodny na klatki GIF‑a?

Tak. [Dodaj półprzezroczysty obiekt/logo](/slides/pl/androidjava/watermark/) do slajdu głównego lub do poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.