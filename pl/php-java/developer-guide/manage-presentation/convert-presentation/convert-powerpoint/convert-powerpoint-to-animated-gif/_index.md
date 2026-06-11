---
title: Konwertuj prezentacje PowerPoint do animowanych GIF‑ów w PHP
linktitle: PowerPoint na GIF
type: docs
weight: 65
url: /pl/php-java/convert-powerpoint-to-animated-gif/
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
- wyeksportuj PPT jako GIF
- wyeksportuj PPTX jako GIF
- ustawienia domyślne
- ustawienia niestandardowe
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Łatwo konwertuj prezentacje PowerPoint (PPT, PPTX) do animowanych GIF‑ów przy użyciu Aspose.Slides dla PHP przez Java. Szybkie, wysokiej jakości wyniki."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint do animowanych plików GIF za pomocą kilku linijek kodu. Jest to przydatne, gdy trzeba udostępnić treść slajdów w lekkim, szeroko obsługiwanym formacie animacji, który można osadzić w stronach internetowych, komunikatorach lub dokumentacji. Ten artykuł wyjaśnia, jak wyeksportować prezentację do GIF przy użyciu ustawień domyślnych oraz jak dostosować wynik, konfigurując opcje takie jak rozmiar klatki, opóźnienie slajdu i częstotliwość klatek przejścia za pomocą klasy [GifOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/gifoptions/).

## **Konwertowanie prezentacji do animowanego GIF przy użyciu ustawień domyślnych**

Ten przykładowy kod pokazuje, jak skonwertować prezentację do animowanego GIF przy użyciu standardowych ustawień:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Animowany GIF zostanie utworzony z domyślnymi parametrami. 

{{%  alert  title="TIP"  color="primary"  %}} 
Jeśli preferujesz dostosować parametry GIF, możesz użyć klasy [GifOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/GifOptions). Zobacz przykładowy kod poniżej.
{{% /alert %}} 

## **Konwertowanie prezentacji do animowanego GIF przy użyciu ustawień niestandardowych**
Ten przykładowy kod pokazuje, jak skonwertować prezentację do animowanego GIF przy użyciu niestandardowych ustawień :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// rozmiar wynikowego GIFa

    $gifOptions->setDefaultDelay(2000);// jak długo każdy slajd będzie wyświetlany, zanim zostanie zmieniony na następny

    $gifOptions->setTransitionFps(35);// zwiększ FPS, aby poprawić jakość animacji przejścia

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Możesz chcieć wypróbować DARMOWY konwerter [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) opracowany przez Aspose. 
{{% /alert %}}

## **FAQ**

**Co jeśli czcionki użyte w prezentacji nie są zainstalowane w systemie?**

Zainstaluj brakujące czcionki lub [configure fallback fonts](/slides/pl/php-java/powerpoint-fonts/). Aspose.Slides zastąpi je, ale wygląd może się różnić. W przypadku brandingu zawsze upewnij się, że wymagane kroje pisma są wyraźnie dostępne.

**Czy mogę nałożyć znak wodny na klatki GIF?**

Tak. [Add a semi-transparent object/logo](/slides/pl/php-java/watermark/) do slajdu głównego lub do poszczególnych slajdów przed eksportem — znak wodny pojawi się na każdej klatce.