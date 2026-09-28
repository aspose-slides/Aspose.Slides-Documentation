---
title: Zastępczy podgląd obiektu przy dodawaniu OleObjectFrame
linktitle: Zastępczy podgląd OLE
type: docs
weight: 10
url: /pl/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem z podglądem
- zastępnik podglądu
- z założenia
- osadzony obiekt
- osadzony plik
- obiekt zmieniony
- podgląd obiektu
- prezentacja
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Dlaczego obiekt OLE dodany za pomocą Aspose.Slides dla .NET wyświetla zastępnik EMBEDDED OLE OBJECT, dopóki jego podgląd nie zostanie zaktualizowany, oraz jak ustawić własny obraz podglądu."
---
## **Wprowadzenie**

Używając Aspose.Slides for .NET, kiedy dodajesz [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe/) do slajdu, na wyjściowym slajdzie wyświetlany jest komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Aby uzyskać więcej informacji o pracy z obiektami OLE, zobacz [Manage OLE](/slides/pl/net/manage-ole/).

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić Cię, że obiekt OLE został zmieniony i podglądowy obraz musi zostać zaktualizowany.

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe/) do slajdu (szczegóły znajdziesz w artykule „Manage OLE”) i następnie otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![OLE object message](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT”, albo możesz kliknąć prawym przyciskiem myszy i przejść do opcji **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint otwiera wtedy osadzony obiekt OLE.

![OLE object data](OLE_object_data.png)

Slajd może zachować komunikat „EMBEDDED OLE OBJECT”. Gdy klikniesz obiekt OLE, podgląd slajdu zostaje zaktualizowany, a komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE.

![OLE object preview](OLE_object_preview.png)

Teraz możesz chcieć zapisać swoją prezentację, aby upewnić się, że obraz obiektu OLE zostanie poprawnie zaktualizowany. W ten sposób po zapisaniu prezentacji, przy ponownym jej otwieraniu nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”.

## **Inne rozwiązania**

### **Rozwiązanie 1: Zastąp komunikat „Embedded OLE Object” obrazem**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić komunikat wybranym przez siebie obrazem podglądu. Poniższe wiersze kodu demonstrują proces:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Slajd zawierający `OleObjectFrame` zmienia się wtedy na następujący:

![New OLE object image](OLE_object_new_image.png)

### **Rozwiązanie 2: Utwórz dodatek dla PowerPoint**

Możesz także utworzyć dodatek dla Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE podczas otwierania prezentacji w programie.