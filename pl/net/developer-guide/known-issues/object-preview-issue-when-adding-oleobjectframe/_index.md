---
title: Problem z podglądem obiektu przy dodawaniu OleObjectFrame
linktitle: Problem z obiektem OLE
type: docs
weight: 10
url: /pl/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- problem z podglądem
- osadzony obiekt
- osadzony plik
- obiekt zmieniony
- podgląd obiektu
- prezentacja
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, dlaczego pojawia się komunikat EMBEDDED OLE OBJECT przy dodawaniu OleObjectFrame w Aspose.Slides dla .NET oraz jak naprawić problemy z podglądem w prezentacjach PPT, PPTX i ODP."
---
## **Wprowadzenie**

Korzystając z Aspose.Slides for .NET, gdy dodajesz [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) do slajdu, na wyjściowym slajdzie wyświetlany jest komunikat „EMBEDDED OLE OBJECT”. Ten komunikat jest zamierzony i NIE jest błędem.

Aby uzyskać więcej informacji o pracy z obiektami OLE, zobacz [Manage OLE](/slides/pl/net/manage-ole/). 

## **Wyjaśnienie i rozwiązanie**

Aspose.Slides wyświetla komunikat „EMBEDDED OLE OBJECT”, aby powiadomić, że obiekt OLE został zmieniony i podglądowy obraz musi zostać zaktualizowany. 

Na przykład, jeśli dodasz wykres Microsoft Excel jako [OleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/oleobjectframe) do slajdu (więcej szczegółów w artykule „Manage OLE”) i otworzysz prezentację w Microsoft PowerPoint, zobaczysz ten obraz na slajdzie:

![Komunikat obiektu OLE](OLE_object_message.png)

Jeśli chcesz sprawdzić i potwierdzić, że twój obiekt OLE został dodany do slajdu, musisz dwukrotnie kliknąć komunikat „EMBEDDED OLE OBJECT” lub możesz kliknąć prawym przyciskiem myszy i wybrać **Object > Edit**.

![Obiekt OLE > Edytuj](OLE_object_edit.png)

PowerPoint otwiera wtedy osadzony obiekt OLE.

![Dane obiektu OLE](OLE_object_data.png)

Slajd może nadal wyświetlać komunikat „EMBEDDED OLE OBJECT”. Po kliknięciu obiektu OLE podgląd slajdu zostaje zaktualizowany, a komunikat „EMBEDDED OLE OBJECT” zostaje zastąpiony rzeczywistym obrazem obiektu OLE. 

![Podgląd obiektu OLE](OLE_object_preview.png)

Teraz możesz zapisać swoją prezentację, aby upewnić się, że obraz obiektu OLE zostanie prawidłowo zaktualizowany. Dzięki temu po zapisaniu i ponownym otwarciu prezentacji nie zobaczysz komunikatu „EMBEDDED OLE OBJECT”. 

## **Inne rozwiązania**

### **Rozwiązanie 1: Zastąp komunikat „Embedded OLE Object” obrazem**

Jeśli nie chcesz usuwać komunikatu „EMBEDDED OLE OBJECT” otwierając prezentację w PowerPoint i zapisując ją, możesz zastąpić ten komunikat wybranym przez siebie obrazem podglądowym. Poniższe wiersze kodu ilustrują proces:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Slajd zawierający `OleObjectFrame` zmienia się wtedy na:

![Nowy obraz obiektu OLE](OLE_object_new_image.png)

### **Rozwiązanie 2: Utwórz dodatek do PowerPoint**

Możesz również stworzyć dodatek dla Microsoft PowerPoint, który aktualizuje wszystkie obiekty OLE podczas otwierania prezentacji w programie.