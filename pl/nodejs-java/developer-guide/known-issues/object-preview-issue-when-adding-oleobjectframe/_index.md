---
title: Problem z podglądem obiektu przy dodawaniu OleObjectFrame
linktitle: Problem z obiektem OLE
type: docs
weight: 10
url: /pl/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
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
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT przy dodawaniu OleObjectFrame w Aspose.Slides dla Node.js oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides for Java, gdy dodasz [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie pojawi się komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Po więcej informacji na temat pracy z obiektami OLE zobacz [Manage OLE](/slides/pl/nodejs-java/manage-ole/). 

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić, że obiekt OLE został zmieniony i należy zaktualizować obraz podglądu. 

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/) do slajdu (szczegóły w artykule „Manage OLE”) i następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![OLE object message](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT”, albo możesz kliknąć prawym przyciskiem myszy i wybrać opcję **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint otwiera wówczas osadzony obiekt OLE.

![OLE object data](OLE_object_data.png)

Slajd może nadal wyświetlać komunikat „EMBEDDED OLE OBJECT”. Gdy klikniesz obiekt OLE, podgląd slajdu zostaje zaktualizowany, a komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE. 

![OLE object preview](OLE_object_preview.png)

Teraz możesz zapisać prezentację, aby upewnić się, że obraz obiektu OLE zostanie prawidłowo zaktualizowany. W ten sposób po zapisaniu prezentacji i ponownym jej otwarciu nie zobaczysz już komunikatu „EMBEDDED OLE OBJECT”. 

## **Inne rozwiązania**

### **Rozwiązanie 1: Zastąp komunikat „Embedded OLE Object” obrazem**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić ten komunikat wybranym obrazem podglądu. Poniższe fragmenty kodu ilustrują proces:

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

Slajd zawierający `OleObjectFrame` zmienia się w następujący sposób:

![New OLE object image](OLE_object_new_image.png)

### **Rozwiązanie 2: Utwórz dodatek do programu PowerPoint**

Możesz także stworzyć dodatek dla Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE podczas otwierania prezentacji w tym programie.