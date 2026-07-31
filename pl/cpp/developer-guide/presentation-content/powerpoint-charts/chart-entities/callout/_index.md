---
title: Zarządzanie dymkami w wykresach prezentacji przy użyciu C++
linktitle: Dymek
type: docs
url: /pl/cpp/callout/
keywords:
- dymek wykresu
- użycie dymka
- etykieta danych
- format etykiet
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Twórz i stylizuj dymki w Aspose.Slides dla C++ za pomocą zwięzłych przykładów kodu, kompatybilnych z formatami PPT i PPTX, aby automatyzować przepływy pracy prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z dymkami dla etykiet danych wykresu w Aspose.Slides. Pokazuje, jak używać metody `set_ShowLabelAsDataCallout`, aby wyświetlać etykiety jako dymki, jak konfigurować ustawienia etykiet związane z dymkami dla wykresu pierścieniowego oraz informuje, że dymki i ich wygląd są zachowywane podczas eksportu prezentacji do formatów PDF, HTML5, SVG i obrazów rastrowych.

## **Używanie dymków**
Nową właściwość **ShowLabelAsDataCallout** dodano do klasy **DataLabelFormat** oraz interfejsu **IDataLabelFormat**, która określa, czy etykieta danych określonego wykresu będzie wyświetlana jako dymek danych, czy jako etykieta danych. W poniższym przykładzie ustawiliśmy dymki.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Ustaw dymek dla wykresu pierścieniowego**
Aspose.Slides dla C++ zapewnia obsługę ustawiania kształtu dymka etykiety danych serii dla wykresu pierścieniowego. Poniżej przedstawiono przykładowy kod.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **FAQ**

**Czy dymki są zachowywane podczas konwersji prezentacji do PDF, HTML5, SVG lub obrazów?**

Tak. Dymki są częścią renderowania wykresu, więc podczas eksportu do [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/),[HTML5](/slides/pl/cpp/export-to-html5/),[SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/) lub [obrazów rastrowych](/slides/pl/cpp/convert-powerpoint-to-png/), są zachowywane razem z formatowaniem slajdu.

**Czy własne czcionki działają w dymkach i czy ich wygląd może być zachowany przy eksporcie?**

Tak. Aspose.Slides obsługuje [osadzanie czcionek](/slides/pl/cpp/embedded-font/) w prezentacji i kontroluje osadzanie czcionek podczas eksportu, takiego jak [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), zapewniając, że dymki wyglądają tak samo na różnych systemach.