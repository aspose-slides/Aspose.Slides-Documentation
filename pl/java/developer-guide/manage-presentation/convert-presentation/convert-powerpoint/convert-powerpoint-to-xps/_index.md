---
title: Konwersja prezentacji PowerPoint do XPS w Javie
linktitle: PowerPoint do XPS
type: docs
weight: 70
url: /pl/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "Konwertuj pliki PowerPoint PPT/PPTX na wysokiej jakości, niezależny od platformy XPS w Javie przy użyciu Aspose.Slides. Uzyskaj instrukcję krok po kroku oraz przykładowy kod."
---
## **Przegląd**

Aspose.Slides umożliwia konwertowanie prezentacji PowerPoint do XPS poprzez zapisanie pliku PPT lub PPTX w formacie XPS. Ten artykuł wyjaśnia, kiedy format XPS może być przydatny i pokazuje, jak wykonać konwersję za pomocą Aspose.Slides używając domyślnych ustawień lub niestandardowych ustawień [XpsOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xpsoptions/).

## **O XPS**
Microsoft opracował [XPS](https://docs.fileformat.com/page-description-language/xps/) jako alternatywę dla [PDF](https://docs.fileformat.com/pdf/). Umożliwia drukowanie zawartości poprzez generowanie pliku bardzo podobnego do PDF. Format XPS opiera się na XML. Układ lub struktura pliku XPS pozostaje taka sama na wszystkich systemach operacyjnych i drukarkach. 

## **Kiedy używać formatu Microsoft XPS**

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje prezentację PPT lub PPTX do formatu XPS, możesz sprawdzić [tę darmową aplikację konwertera online](https://products.aspose.app/slides/pl/conversion). 

{{% /alert %}} 

Jeśli chcesz obniżyć koszty przechowywania, możesz przekonwertować swoją prezentację Microsoft PowerPoint do formatu XPS. Dzięki temu łatwiej będzie zapisywać, udostępniać i drukować dokumenty. 

Microsoft nadal intensywnie wspiera XPS w systemie Windows (nawet w Windows 10), więc warto rozważyć zapisywanie plików w tym formacie. Jeśli pracujesz z Windows 8.1, Windows 8, Windows 7 lub Windows Vista, XPS może być w rzeczywistości najlepszą opcją dla niektórych operacji. 

- **Windows 8** używa formatu OXPS (Open XPS) dla plików XPS. OXPS jest ustandaryzowaną wersją oryginalnego formatu XPS. Windows 8 zapewnia lepsze wsparcie dla plików XPS niż dla plików PDF. 
  - **XPS:** Wbudowana przeglądarka/odczytnik XPS oraz dostępna funkcja drukowania do XPS. 
  - **PDF:** Dostępny czytnik PDF, ale brak funkcji drukowania do PDF. 

- **Windows 7 i Windows Vista** używają oryginalnego formatu XPS. Te systemy operacyjne również zapewniają lepsze wsparcie dla plików XPS niż dla PDF. 
  - **XPS:** Wbudowany przeglądarka XPS i dostępna funkcja drukowania do XPS. 
  - **PDF:** Brak czytnika PDF. Brak funkcji drukowania do PDF. 

|<p>**Wejściowy PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Wyjściowy XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft ostatecznie wprowadził obsługę operacji drukowania w formacie PDF poprzez funkcję Drukuj do PDF w Windows 10. Wcześniej użytkownicy byli zobowiązani do drukowania dokumentów przy użyciu formatu XPS. 

## **Konwersja XPS za pomocą Aspose.Slides**

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/java/) dla Javy możesz użyć metody [**Save**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation), aby przekonwertować całą prezentację na dokument XPS. 

Podczas konwertowania prezentacji do XPS musisz zapisać ją, używając jednej z poniższych konfiguracji:

- Domyślne ustawienia (bez [**XPSOptions**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xpsoptions))
- Niestandardowe ustawienia (z [**XPSOptions**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xpsoptions))

### **Konwertowanie prezentacji do XPS przy użyciu domyślnych ustawień**

Ten przykładowy kod w Javie pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu standardowych ustawień:

```java
// Utwórz obiekt Presentation reprezentujący plik prezentacji
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Zapis prezentacji do dokumentu XPS
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Konwertowanie prezentacji do XPS przy użyciu niestandardowych ustawień**
Ten przykładowy kod pokazuje, jak przekonwertować prezentację na dokument XPS przy użyciu niestandardowych ustawień w Javie:

```java
// Utwórz obiekt Presentation reprezentujący plik prezentacji
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Utwórz instancję klasy TiffOptions
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

**Czy mogę zapisać XPS do strumienia zamiast do pliku?**

Tak — Aspose.Slides pozwala eksportować bezpośrednio do strumienia, co jest idealne dla API internetowych, potoków po stronie serwera lub każdego scenariusza, w którym chcesz przesłać XPS bez zapisywania go na dysku.

**Czy ukryte slajdy są przenoszone do XPS i czy mogę je wykluczyć?**

Domyślnie renderowane są tylko zwykłe (widoczne) slajdy. Możesz [uwzględnić lub wykluczyć ukryte slajdy](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) poprzez [ustawienia eksportu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/xpsoptions/) przed zapisaniem do XPS, zapewniając, że wynik zawiera dokładnie te strony, które zamierzasz.