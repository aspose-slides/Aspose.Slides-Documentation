---
title: Problem z podglądem obiektu podczas dodawania OleObjectFrame
linktitle: Problem z obiektem OLE
type: docs
weight: 10
url: /pl/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem z podglądem
- osadzony obiekt
- osadzony plik
- obiekt zmieniony
- podgląd obiektu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT podczas dodawania OleObjectFrame w Aspose.Slides for Java oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides for Java, gdy dodasz [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie wyświetlany jest komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Aby uzyskać więcej informacji na temat pracy z obiektami OLE, zobacz [Manage OLE](/slides/pl/java/manage-ole/).

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić, że obiekt OLE został zmieniony i obraz podglądu musi zostać zaktualizowany. 

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/oleobjectframe/) do slajdu (szczegóły w artykule „Manage OLE”) i potem otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![OLE object message](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT”, lub możesz kliknąć prawym przyciskiem i wybrać opcję **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint otwiera następnie osadzony obiekt OLE.

![OLE object data](OLE_object_data.png)

Slajd może nadal wyświetlać komunikat „EMBEDDED OLE OBJECT”. Po kliknięciu obiektu OLE podgląd slajdu zostaje zaktualizowany, a komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE. 

![OLE object preview](OLE_object_preview.png)

Teraz możesz chcieć zapisać prezentację, aby zapewnić prawidłową aktualizację obrazu obiektu OLE. W ten sposób, po zapisaniu prezentacji, po ponownym otwarciu nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”. 

## **Inne rozwiązania**

### **Rozwiązanie 1: Zastąp komunikat „Embedded OLE Object” obrazem**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić go wybranym obrazem podglądu. Poniższe fragmenty kodu demonstrują ten proces:

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

Slajd zawierający `OleObjectFrame` zmieni się wtedy na następujący:

![New OLE object image](OLE_object_new_image.png)

### **Rozwiązanie 2: Stwórz dodatek do PowerPoint**

Możesz także stworzyć dodatek do Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE podczas otwierania prezentacji w programie.