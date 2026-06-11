---
title: Problem z podglądem obiektu przy dodawaniu OleObjectFrame
linktitle: Problem z obiektem OLE
type: docs
weight: 10
url: /pl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem z podglądem
- osadzony obiekt
- osadzony plik
- obiekt zmieniony
- podgląd obiektu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT po dodaniu OleObjectFrame w Aspose.Slides dla Node.js i jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Używając Aspose.Slides for Java, gdy dodasz [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie wyświetlany jest komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Aby uzyskać więcej informacji na temat pracy z obiektami OLE, zobacz [Manage OLE](/slides/pl/nodejs-java/manage-ole/). 

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić Cię, że obiekt OLE został zmieniony i podglądowy obraz musi zostać zaktualizowany. 

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/) do slajdu (po więcej szczegółów zobacz artykuł „Manage OLE”) i następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![Komunikat OLE object](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że Twój obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT”, lub możesz kliknąć prawym przyciskiem myszy i wybrać opcję **Object > Edit**.

![Obiekt OLE > Edit](OLE_object_edit.png)

PowerPoint następnie otwiera osadzony obiekt OLE.

![Dane obiektu OLE](OLE_object_data.png)

Slajd może zachować komunikat „EMBEDDED OLE OBJECT”. Po kliknięciu obiektu OLE podgląd slajdu zostaje zaktualizowany, a komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE. 

![Podgląd obiektu OLE](OLE_object_preview.png)

Teraz możesz chcieć zapisać prezentację, aby upewnić się, że obraz obiektu OLE został poprawnie zaktualizowany. W ten sposób, po zapisaniu prezentacji, po ponownym jej otwarciu nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”. 

## **Inne rozwiązania**

### **Rozwiązanie 1: Zamiana komunikatu „Embedded OLE Object” na obraz**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić komunikat wybranym przez siebie obrazem podglądu. Poniższe fragmenty kodu demonstrują proces:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Dodaj obraz do zasobów prezentacji.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Ustaw tytuł i obraz podglądu obiektu OLE.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Slajd zawierający `OleObjectFrame` zmienia się wtedy na:

![Nowy obraz obiektu OLE](OLE_object_new_image.png)

### **Rozwiązanie 2: Utworzenie dodatku do PowerPoint**

Możesz także stworzyć dodatek do Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE podczas otwierania prezentacji w programie.