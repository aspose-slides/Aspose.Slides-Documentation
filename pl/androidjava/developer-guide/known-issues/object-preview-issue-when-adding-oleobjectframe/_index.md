---
title: Problem z podglądem obiektu przy dodawaniu OleObjectFrame
linktitle: Problem z obiektem OLE
type: docs
weight: 10
url: /pl/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem z podglądem
- osadzony obiekt
- osadzony plik
- obiekt zmieniony
- podgląd obiektu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT przy dodawaniu OleObjectFrame w Aspose.Slides dla Androida za pomocą Javy oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Używając Aspose.Slides for Android via Java, gdy dodasz [OleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie pojawia się komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Po więcej informacji o pracy z obiektami OLE zobacz [Zarządzanie OLE](/slides/pl/androidjava/manage-ole/). 

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić, że obiekt OLE został zmieniony i podgląd obrazu musi zostać zaktualizowany. 

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/oleobjectframe/) do slajdu (szczegóły w artykule „Zarządzanie OLE”) i potem otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![Komunikat obiektu OLE](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że Twój obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT” lub możesz kliknąć prawym przyciskiem myszy i wybrać **Obiekt > Edytuj**.

![Obiekt OLE > Edytuj](OLE_object_edit.png)

PowerPoint otworzy wbudowany obiekt OLE.

![Dane obiektu OLE](OLE_object_data.png)

Slajd może nadal wyświetlać komunikat „EMBEDDED OLE OBJECT”. Po kliknięciu obiektu OLE podgląd slajdu zostanie zaktualizowany, a komunikat zostanie zastąpiony rzeczywistym obrazem obiektu OLE. 

![Podgląd obiektu OLE](OLE_object_preview.png)

Teraz możesz zapisać prezentację, aby zapewnić prawidłową aktualizację obrazu obiektu OLE. Dzięki temu po zapisaniu i ponownym otwarciu prezentacji nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”. 

## **Inne rozwiązania**

### **Rozwiązanie 1: Zastąp komunikat „Embedded OLE Object” obrazem**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić komunikat wybranym przez siebie obrazem podglądu. Poniższe linie kodu demonstrują ten proces:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Dodaj obraz do zasobów prezentacji.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Ustaw tytuł i obraz podglądu obiektu OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Slajd zawierający `OleObjectFrame` zmieni się na:

![Nowy obraz obiektu OLE](OLE_object_new_image.png)

### **Rozwiązanie 2: Utwórz dodatek do PowerPoint**

Możesz także stworzyć dodatek do Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE przy otwieraniu prezentacji w programie.