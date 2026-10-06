---
title: Placeholder podglądu obiektu przy dodawaniu OleObjectFrame
linktitle: Placeholder podglądu OLE
type: docs
weight: 10
url: /pl/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem podglądu
- placeholder podglądu
- zamierzone
- osadzony obiekt
- osadzony plik
- obiekt zmieniony
- podgląd obiektu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dlaczego obiekt OLE dodany przy użyciu Aspose.Slides for Java wyświetla placeholder EMBEDDED OLE OBJECT, dopóki jego podgląd nie zostanie zaktualizowany, oraz jak ustawić własny obraz podglądu."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides for Java, gdy dodajesz [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie wyświetlany jest komunikat "EMBEDDED OLE OBJECT". Ten komunikat jest zamierzony i nie jest błędem.

Aby uzyskać więcej informacji na temat pracy z obiektami OLE, zobacz [Manage OLE](/slides/pl/java/manage-ole/).

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat "EMBEDDED OLE OBJECT", aby powiadomić Cię, że obiekt OLE został zmieniony i obraz podglądu musi zostać zaktualizowany.

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/oleobjectframe/) do slajdu (po więcej szczegółów zobacz artykuł "Manage OLE") i następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![OLE object message](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat "EMBEDDED OLE OBJECT", lub możesz kliknąć prawym przyciskiem myszy i wybrać opcję **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint otwiera następnie osadzony obiekt OLE.

![OLE object data](OLE_object_data.png)

Slajd może zachować komunikat "EMBEDDED OLE OBJECT". Po kliknięciu obiektu OLE podgląd slajdu zostanie zaktualizowany, a komunikat "EMBEDDED OLE OBJECT" zostanie zastąpiony rzeczywistym obrazem obiektu OLE.

![OLE object preview](OLE_object_preview.png)

Teraz możesz chcieć zapisać prezentację, aby zapewnić poprawną aktualizację obrazu obiektu OLE. W ten sposób, po zapisaniu prezentacji, po ponownym jej otwarciu nie zobaczysz komunikatu "EMBEDDED OLE OBJECT".

## **Inne rozwiązanie**

Jeśli nie chcesz usuwać komunikatu "EMBEDDED OLE OBJECT" otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić komunikat wybranym przez siebie obrazem podglądu. Poniższe linie kodu demonstrują ten proces. Zakładają, że pierwszym kształtem na pierwszym slajdzie pliku *embeddedOLE.pptx* jest ramka obiektu OLE oraz że *myImage.png* zawiera obraz do wyświetlenia, a wynik zapisują jako *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Dodaj obraz do zasobów prezentacji.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Ustaw obraz podglądu obiektu OLE.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Slajd zawierający `OleObjectFrame` zostaje wtedy zmieniony na następujący:

![New OLE object image](OLE_object_new_image.png)