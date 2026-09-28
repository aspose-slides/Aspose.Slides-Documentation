---
title: Wdrożenie i Aktywacja
type: docs
weight: 20
url: /pl/sharepoint/deployment-and-activation/
description: "Co rozwiązanie Aspose.Slides for SharePoint instaluje w farmie po wdrożeniu oraz co jego funkcja kolekcji witryn dodaje po aktywacji."
---
## **Wdrożenie**

Podczas wdrożenia rozwiązanie Aspose.Slides for SharePoint:

- Instaluje swój zestaw w Global Assembly Cache i dodaje wpisy SafeControl do pliku **web.config**. W SharePoint 2010 i nowszych są to *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* lub *Aspose.Slides.SharePoint2016.dll* (pakiet SharePoint 2019 również instaluję *Aspose.Slides.SharePoint2016.dll*). W SharePoint 2007 jest to *Aspose.Slides.SharePointUI.dll* wraz z *Aspose.Slides.SharePoint.Deployment.dll*.
- Kopiuje stronę konwersji oraz jej obrazy i inne pliki pomocnicze do folderów instalacji SharePoint.
- Instaluje funkcję i udostępnia ją do aktywacji w kolekcjach witryn.

## **Aktywacja**

Aspose.Slides for SharePoint jest pakowany jako funkcja kolekcji witryn i może być aktywowana lub dezaktywowana w kolekcjach witryn. Po aktywacji w kolekcji witryn funkcja dodaje:

- W SharePoint 2010 i nowszych:
  - pozycję **Convert via Aspose.Slides** do menu dokumentów w bibliotekach dokumentów;
  - kartę wstążki **Aspose Tools** z przyciskiem **Convert Slides**, który konwertuje wybrane dokumenty;
  - pozycję **View Slides** do menu plików PPT, PPTX, PPS i PPSX.
- W SharePoint 2007:
  - pozycję **Convert with Aspose.Slides** do menu dokumentów w bibliotekach dokumentów;
  - pozycję **Convert All with Aspose.Slides** do menu **Actions** w bibliotekach dokumentów.

W SharePoint 2007 aktywacja wprowadza także zmiany w wirtualnym katalogu nadrzędnej aplikacji internetowej kolekcji witryn. Robi to:

- Dodaje stronę ustawień konwersji do pliku mapy witryny.
- Kopiuje niezbędne pliki zasobów do folderu App_GlobalResources w wirtualnym katalogu.

Program instalacyjny aktywuje funkcję w wybranych kolekcjach witryn podczas [instalacji](/slides/pl/sharepoint/installing-aspose-slides-for-sharepoint/).