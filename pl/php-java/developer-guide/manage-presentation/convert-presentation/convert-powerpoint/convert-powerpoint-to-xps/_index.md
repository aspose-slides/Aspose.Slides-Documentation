---
title: Konwertuj prezentacje PowerPoint do XPS w PHP
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /pl/php-java/convert-powerpoint-to-xps/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do XPS
- prezentacja do XPS
- slajd do XPS
- PPT do XPS
- PPTX do XPS
- zapisz PPT jako XPS
- zapisz PPTX jako XPS
- eksportuj PPT do XPS
- eksportuj PPTX do XPS
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Konwertuj PowerPoint PPT/PPTX do wysokiej jakości, niezależnego od platformy XPS za pomocą Aspose.Slides dla PHP poprzez Java. Uzyskaj przewodnik krok po kroku oraz przykładowy kod."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint do XPS poprzez zapisanie pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję za pomocą Aspose.Slides używając domyślnych ustawień lub niestandardowych ustawień [XpsOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xpsoptions/) .

## **O XPS**
Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia drukowanie treści poprzez generowanie pliku bardzo podobnego do PDF. Format XPS oparty jest na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach. 

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz sprawdzić [tę darmową aplikację konwertera online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz obniżyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. W ten sposób łatwiej będzie zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal zapewnia silne wsparcie dla XPS w systemie Windows (nawet w Windows 10), więc możesz rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 i Windows Vista, wtedy XPS może być faktycznie najlepszą opcją dla niektórych operacji. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest standaryzowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** Wbudowana przeglądarka/odczytnik XPS oraz dostępna funkcja drukowania do XPS. 
  - **PDF**: Dostępny czytnik PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS**: Wbudowana przeglądarka XPS oraz dostępna funkcja drukowania do XPS. 
  - **PDF**: Brak czytnika PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejście PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził wsparcie dla operacji drukowania w PDF poprzez funkcję Drukuj do PDF w Windows 10. Wcześniej użytkownicy mieli drukować dokumenty przy użyciu formatu XPS. 

## **Konwersja XPS przy użyciu Aspose.Slides**

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/php-java/) dla Javy, możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation), aby przekonwertować całą prezentację na dokument XPS.

Podczas konwertowania prezentacji do XPS, musisz zapisać prezentację używając jednego z tych ustawień:

- Ustawienia domyślne (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xpsoptions))
- Ustawienia niestandardowe (z [**XPSOptions**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xpsoptions))

### **Konwertuj prezentacje do XPS używając ustawień domyślnych**

Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu standardowych ustawień:

```php
  # Utwórz obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # Zapisz prezentację do dokumentu XPS
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Konwertuj prezentacje do XPS używając ustawień niestandardowych**
Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu ustawień niestandardowych :

```php
  # Utwórz obiekt Presentation, który reprezentuje plik prezentacji
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Utwórz instancję klasy XpsOptions
    $options = new XpsOptions();
    # Zapisz MetaFiles jako PNG
    $options->setSaveMetafilesAsPng(true);
    # Zapisz prezentację do dokumentu XPS
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak — Aspose.Slides pozwala eksportować bezpośrednio do strumienia, co jest idealne dla interfejsów API webowych, potoków po stronie serwera lub każdego scenariusza, w którym chcesz przesłać XPS bez korzystania z systemu plików.

**Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?**

Domyślnie renderowane są tylko regularne (widoczne) slajdy. Możesz [uwzględnić lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/xpsoptions/) przed zapisaniem do XPS, zapewniając, że wynik zawiera dokładnie te strony, które zamierzasz.