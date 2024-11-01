---
title: Установить заголовок для OLE-иконки
type: docs
weight: 160
url: /ru/net/set-caption-to-ole-icon/
---

В интерфейс **IOleObjectFrame** и класс **OleObjectFrame** добавлено новое свойство **SubstitutePictureTitle**. Оно позволяет получать, устанавливать или изменять заголовок OLE-иконки. Приведенный ниже фрагмент кода демонстрирует пример создания объекта Excel и установки его заголовка.

```csharp
using (Presentation pres = new Presentation())
{
    IPPImage image = null;
    ISlide slide = pres.Slides[0];

    // Добавление OLE объектов
    byte[] allbytes = File.ReadAllBytes("oleSourceFile.bin");
    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allbytes, "xls");
    
    IOleObjectFrame oof = slide.Shapes.AddOleObjectFrame(20, 20, 50, 50, dataInfo);
    oof.IsObjectIcon = true;

    // Добавление объекта изображения
    byte[] imgBuf = File.ReadAllBytes("oleIconFile.ico");
    using (MemoryStream ms = new MemoryStream(imgBuf))
    {
        image = pres.Images.AddImage(new Bitmap(ms));
    }
    oof.SubstitutePictureFormat.Picture.Image = image;

    // Установить заголовок для OLE-иконки
    oof.SubstitutePictureTitle = "Пример заголовка";
}
```