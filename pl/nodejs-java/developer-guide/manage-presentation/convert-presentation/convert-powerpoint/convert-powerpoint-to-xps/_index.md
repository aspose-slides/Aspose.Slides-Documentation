---
title: "Konwertuj prezentacje PowerPoint do XPS w JavaScript"
linktitle: "PowerPoint do XPS"
type: docs
weight: 70
url: /pl/nodejs-java/convert-powerpoint-to-xps/
keywords:
- "konwertuj PowerPoint"
- "konwertuj prezentację"
- "konwertuj slajd"
- "konwertuj PPT"
- "konwertuj PPTX"
- "PowerPoint do XPS"
- "prezentacja do XPS"
- "slajd do XPS"
- "PPT do XPS"
- "PPTX do XPS"
- "zapisz PPT jako XPS"
- "zapisz PPTX jako XPS"
- "eksportuj PPT do XPS"
- "eksportuj PPTX do XPS"
- "PowerPoint"
- "prezentacja"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Konwertuj pliki PowerPoint PPT/PPTX do wysokiej jakości, platformowo niezależnego XPS w JavaScript przy użyciu Aspose.Slides dla Node.js. Uzyskaj instrukcję krok po kroku oraz przykładowy kod."
---
## **Przegląd**

Aspose.Slides umożliwia konwersję prezentacji PowerPoint do formatu XPS poprzez zapisanie pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję przy użyciu Aspose.Slides z domyślnymi ustawieniami lub własnymi ustawieniami [XpsOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xpsoptions/).

## **O XPS**

Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia on drukowanie zawartości, generując plik bardzo podobny do PDF. Format XPS oparty jest na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach.

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz wypróbować [tę darmową aplikację konwertera online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz zmniejszyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. Dzięki temu łatwiej będzie zapisywać, udostępniać i drukować dokumenty.

Microsoft nadal intensywnie wspiera XPS w systemie Windows (nawet w Windows 10), więc warto rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 lub Windows Vista, XPS może być najlepszą opcją dla niektórych operacji.

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest ustandaryzowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** Wbudowany podgląd/odczytnik XPS oraz możliwość drukowania do XPS. 
  - **PDF:** Dostępny czytnik PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla PDF. 
  - **XPS:** Wbudowany podgląd XPS oraz możliwość drukowania do XPS. 
  - **PDF:** Brak czytnika PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejście PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził obsługę operacji drukowania w formacie PDF poprzez funkcję Drukuj do PDF w Windows 10. Wcześniej użytkownicy byli zmuszeni do drukowania dokumentów za pośrednictwem formatu XPS.

## **Konwersja XPS za pomocą Aspose.Slides**

W [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/pl/nodejs-java/), możesz użyć metody [**save**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation), aby przekonwertować całą prezentację na dokument XPS.

Podczas konwersji prezentacji do XPS należy zapisać prezentację, używając jednej z poniższych opcji:

- Domyślne ustawienia (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xpsoptions))
- Własne ustawienia (z [**XPSOptions**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xpsoptions))

### **Konwersja prezentacji do XPS przy użyciu domyślnych ustawień**

Ten przykładowy kod w JavaScript pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu standardowych ustawień:

```javascript
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // Zapis prezentacji do dokumentu XPS
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Konwersja prezentacji do XPS przy użyciu własnych ustawień**

Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu własnych ustawień w JavaScript:

```javascript
// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Utwórz instancję klasy TiffOptions
    var options = new aspose.slides.XpsOptions();
    // Zapisz MetaFiles jako PNG
    options.setSaveMetafilesAsPng(true);
    // Zapisz prezentację do dokumentu XPS
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak — Aspose.Slides umożliwia eksport bezpośrednio do strumienia, co jest idealne dla interfejsów API webowych, potoków po stronie serwera lub każdego scenariusza, w którym chcesz przesłać XPS bez zapisu na dysk.

**Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?**

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [uwzględnić lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/xpsoptions/) przed zapisaniem do XPS, zapewniając, że wynik zawiera dokładnie te strony, które zamierzasz.