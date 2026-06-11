---
title: Zarządzaj odnośnikami w wykresach prezentacji przy użyciu С++
linktitle: Odnośnik
type: docs
url: /pl/cpp/callout/
keywords:
- odnośnik wykresu
- użycie odnośnika
- etykieta danych
- format etykiety
- PowerPoint
- prezentacja
- С++
- Aspose.Slides
description: "Twórz i stylizuj odnośniki w Aspose.Slides dla С++ za pomocą zwięzłych przykładów kodu, kompatybilnych z PPT i PPTX, aby automatyzować przepływy pracy prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z odnośnikami dla etykiet danych wykresu w Aspose.Slides. Pokazuje, jak używać metody `set_ShowLabelAsDataCallout`, aby wyświetlać etykiety jako odnośniki, jak konfigurować ustawienia etykiet związane z odnośnikami dla wykresu pierścieniowego oraz informuje, że odnośniki i ich wygląd są zachowywane podczas eksportu prezentacji do formatów PDF, HTML5, SVG i formatów obrazów rastrowych.

## **Używanie odnośników**
Do klasy **DataLabelFormat** i interfejsu **IDataLabelFormat** została dodana nowa właściwość **ShowLabelAsDataCallout**, która określa, czy etykieta danych wybranego wykresu będzie wyświetlana jako odnośnik danych, czy jako etykieta danych. W poniższym przykładzie ustawiono odnośniki.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Ustaw odnośnik dla wykresu pierścieniowego**
Aspose.Slides dla C++ zapewnia obsługę ustawiania kształtu odnośnika etykiety danych serii dla wykresu pierścieniowego. Poniżej podano przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Czy odnośniki są zachowywane przy konwertowaniu prezentacji do PDF, HTML5, SVG lub obrazów?**

Tak. Odnośniki są częścią renderowania wykresu, więc przy eksporcie do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/pl/cpp/export-to-html5/), [SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/) lub [obrazów rastrowych](/slides/pl/cpp/convert-powerpoint-to-png/), są zachowywane razem z formatowaniem slajdu.

**Czy niestandardowe czcionki działają w odnośnikach i czy ich wygląd może być zachowany przy eksporcie?**

Tak. Aspose.Slides obsługuje [osadzanie czcionek](/slides/pl/cpp/embedded-font/) w prezentacji i kontroluje ich osadzanie podczas eksportu, na przykład do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), zapewniając, że odnośniki wyglądają tak samo na różnych systemach.