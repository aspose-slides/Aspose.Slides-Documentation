---
title: Problem z podglądem obiektu przy dodawaniu OleObjectFrame
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
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT podczas dodawania OleObjectFrame w Aspose.Slides dla Javy oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides for Java, gdy dodasz [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie pojawia się komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Aby uzyskać więcej informacji na temat pracy z obiektami OLE, zobacz [Manage OLE](/slides/pl/java/manage-ole/).

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić Cię, że obiekt OLE został zmieniony i obraz podglądu musi zostać zaktualizowany. 

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/oleobjectframe/) do slajdu (po więcej szczegółów zobacz artykuł „Manage OLE”) i następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![Komunikat obiektu OLE](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT”, albo możesz kliknąć go prawym przyciskiem myszy i wybrać opcję **Object > Edit**.

![Obiekt OLE > Edytuj](OLE_object_edit.png)

PowerPoint otwiera wtedy osadzony obiekt OLE.

![Dane obiektu OLE](OLE_object_data.png)

Slajd może nadal wyświetlać komunikat „EMBEDDED OLE OBJECT”. Gdy klikniesz obiekt OLE, podgląd slajdu zostaje zaktualizowany i komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE. 

![Podgląd obiektu OLE](OLE_object_preview.png)

Teraz możesz chcieć zapisać prezentację, aby upewnić się, że obraz obiektu OLE zostanie poprawnie zaktualizowany. W ten sposób, po zapisaniu prezentacji, przy ponownym otwarciu nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”. 

## **Inne rozwiązanie**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” poprzez otwarcie prezentacji w PowerPoint i jej zapisanie, możesz zastąpić komunikat wybranym przez siebie obrazem podglądu. Poniższe linie kodu demonstrują ten proces:

```java
import com.aspose.slides.*;

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

Slajd zawierający `OleObjectFrame` zostaje wtedy zmieniony na następujący:

![Nowy obraz obiektu OLE](OLE_object_new_image.png)