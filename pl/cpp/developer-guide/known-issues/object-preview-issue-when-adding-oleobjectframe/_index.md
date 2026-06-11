---
title: Problem z podglądem obiektu przy dodawaniu OleObjectFrame
linktitle: Problem z obiektem OLE
type: docs
weight: 10
url: /pl/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem z podglądem
- osadzony obiekt
- osadzony plik
- zmieniony obiekt
- podgląd obiektu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT przy dodawaniu OleObjectFrame w Aspose.Slides for C++ oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Używając Aspose.Slides for C++, gdy dodajesz [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie pojawia się komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i **nie** jest błędem.

Aby uzyskać więcej informacji o pracy z obiektami OLE, zobacz [Zarządzanie OLE](/slides/pl/cpp/manage-ole/). 

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby poinformować, że obiekt OLE został zmieniony i że podglądowy obraz musi zostać zaktualizowany. 

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/oleobjectframe/) do slajdu (szczegóły w artykule „Zarządzanie OLE”), a następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![OLE object message](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT” lub kliknąć go prawym przyciskiem myszy i wybrać **Obiekt > Edytuj**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint otworzy wbudowany obiekt OLE.

![OLE object data](OLE_object_data.png)

Slajd może nadal wyświetlać komunikat „EMBEDDED OLE OBJECT”. Po kliknięciu obiektu OLE podgląd slajdu zostaje zaktualizowany, a komunikat zostaje zastąpiony rzeczywistym obrazem obiektu OLE. 

![OLE object preview](OLE_object_preview.png)

Teraz możesz zapisać prezentację, aby upewnić się, że obraz obiektu OLE został poprawnie zaktualizowany. Dzięki temu po ponownym otwarciu prezentacji nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”. 

## **Inne rozwiązania**

### **Rozwiązanie 1: Zamiana komunikatu „Embedded OLE Object” na obraz**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić ten komunikat wybranym obrazem podglądu. Poniższe fragmenty kodu ilustrują proces:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Slajd zawierający `OleObjectFrame` zostaje wtedy zmieniony na:

![New OLE object image](OLE_object_new_image.png)

### **Rozwiązanie 2: Utworzenie dodatku do PowerPoint**

Możesz również stworzyć dodatek dla Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE podczas otwierania prezentacji w programie.