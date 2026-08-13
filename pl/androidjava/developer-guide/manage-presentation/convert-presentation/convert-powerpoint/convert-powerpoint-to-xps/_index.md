---
title: Konwertuj prezentacje PowerPoint na XPS w systemie Android
linktitle: PowerPoint na XPS
type: docs
weight: 70
url: /pl/androidjava/convert-powerpoint-to-xps/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na XPS
- prezentacja na XPS
- slajd na XPS
- PPT na XPS
- PPTX na XPS
- zapisz PPT jako XPS
- zapisz PPTX jako XPS
- eksportuj PPT do XPS
- eksportuj PPTX do XPS
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint PPT/PPTX na wysokiej jakości, platformowo niezależny XPS w Javie przy użyciu Aspose.Slides dla Androida. Uzyskaj szczegółowy przewodnik i przykładowy kod."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint do formatu XPS poprzez zapisanie pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję przy użyciu Aspose.Slides przy użyciu domyślnych ustawień lub niestandardowych ustawień [XpsOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions/) .

## **O XPS**

Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia drukowanie treści poprzez wygenerowanie pliku bardzo podobnego do PDF. Format XPS oparty jest na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach. 

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="info" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz sprawdzić [tę darmową aplikację konwertera online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz zmniejszyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. Dzięki temu łatwiej będzie zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal wprowadza silne wsparcie dla XPS w systemie Windows (nawet w Windows 10), więc warto rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 i Windows Vista, XPS może być faktycznie najlepszą opcją dla niektórych operacji. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest znormalizowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** Wbudowana przeglądarka/odczytywacz XPS oraz dostępna funkcja drukowania do XPS. 
  - **PDF**: Dostępny czytnik PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla PDF. 
  - **XPS**: Wbudowana przeglądarka XPS i dostępna funkcja drukowania do XPS. 
  - **PDF**: Brak czytnika PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejście PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjście XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził obsługę operacji drukowania w formacie PDF poprzez funkcję Drukuj do PDF w Windows 10. Wcześniej użytkownicy mieli drukować dokumenty za pośrednictwem formatu XPS. 

## **Konwersja XPS przy użyciu Aspose.Slides**

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/androidjava/) dla Javy możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation), aby przekonwertować całą prezentację na dokument XPS.

Podczas konwertowania prezentacji do XPS musisz zapisać prezentację używając jednego z tych ustawień:

- Ustawienia domyślne (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions))
- Ustawienia niestandardowe (z [**XPSOptions**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions))

### **Konwertuj prezentacje do XPS przy użyciu ustawień domyślnych**

Ten przykładowy kod w Javie pokazuje, jak skonwertować prezentację do dokumentu XPS przy użyciu standardowych ustawień:

```java
import com.aspose.slides.*;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Zapisanie prezentacji do dokumentu XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Konwertuj prezentacje do XPS przy użyciu ustawień niestandardowych**

Ten przykładowy kod pokazuje, jak skonwertować prezentację do dokumentu XPS przy użyciu niestandardowych ustawień w Javie:

```java
import com.aspose.slides.*;

// Utwórz obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Utwórz obiekt klasy XpsOptions
    XpsOptions options = new XpsOptions();

    // Zapisz MetaFiles jako PNG
    options.setSaveMetafilesAsPng(true);

    // Zapisz prezentację do dokumentu XPS
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Czy mogę zapisać XPS do strumienia zamiast do pliku?

Tak—Aspose.Slides umożliwia eksport bezpośrednio do strumienia, co jest idealne dla interfejsów API webowych, potoków po stronie serwera lub wszelkich scenariuszy, w których chcesz wysłać XPS bez dotykania systemu plików.

### Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [włączyć lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/xpsoptions/) przed zapisem do XPS, zapewniając, że wynik zawiera dokładnie te strony, które zamierzasz.