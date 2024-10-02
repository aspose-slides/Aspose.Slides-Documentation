---
title: Проблема с изменением объекта при добавлении OleObjectFrame
type: docs
weight: 10
url: /ru/net/object-changed-issue-when-adding-oleobjectframe/
---

{{% alert color="primary" %}} 

Используя Aspose.Slides для .NET, при добавлении **[OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe)** на слайд, на выходном слайде отображается сообщение **Изменен объект** (и не на OLE объекте). Описанный процесс является преднамеренным действием и не является ошибкой. 

Для получения дополнительной информации о работе с OLE объектами смотрите [Управление OLE](/slides/ru/net/manage-ole/). 

{{% /alert %}} 
## **Объяснение** и решение
Aspose.Slides отображает сообщение **Изменен объект** для уведомления о том, что OLE объект был изменен, и изображение предпросмотра необходимо обновить. 

Например, если вы добавите диаграмму Microsoft Excel в качестве [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд (для получения более подробной информации смотрите статью Управление OLE) и затем откроете презентацию в приложении Microsoft PowerPoint, вы увидите это изображение на слайде:

~~Замените все изображения на новые изображения~~

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

Если вы хотите проверить и подтвердить, что ваш OLE объект был добавлен на слайд, вам нужно дважды щелкнуть по сообщению **Изменен объект**, или щелкнуть правой кнопкой мыши по нему и пройти через **Объект рабочего листа > Опция редактирования.**

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

PowerPoint затем откроет встроенный OLE объект

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)



Слайд может сохранять сообщение **Изменен объект**. Как только вы щелкните по OLE объекту, предпросмотр слайда обновится, и сообщение **Изменен объект** будет заменено фактическим изображением OLE объекта. 

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

Теперь вы можете сохранить свою презентацию, чтобы убедиться, что изображение для OLE объекта обновлено правильно. Таким образом, после сохранения презентации, когда вы снова откроете ее, вы НЕ увидите сообщение **Изменен объект**.

## **Другие решения**
### **Решение 1: Замените сообщение об изменении объекта изображением**

Если вы не хотите удалять сообщение **Изменен объект** путем открытия презентации в PowerPoint и затем ее сохранения, вы можете заменить сообщение на свое предпочтительное изображение предпросмотра. Эти строки кода демонстрируют процесс:

``` csharp 
using (Presentation pres = new Presentation("embeddedOle.pptx"))
{
   ISlide slide = pres.Slides[0];
   IOleObjectFrame oleObjectFrame = (IOleObjectFrame)slide.Shapes[0];
    
   IPPImage oleImage = pres.Images.AddImage(File.ReadAllBytes("my_image.png"));
   oleObjectFrame.SubstitutePictureTitle = "Мой заголовок";
   oleObjectFrame.SubstitutePictureFormat.Picture.Image = oleImage;
   oleObjectFrame.IsObjectIcon = false;
    
   pres.Save("embeddedOle-newImage.pptx", SaveFormat.Pptx);
}
```

Слайд, содержащий `OleObjectFrame`, затем изменится на это:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

### **Решение 2: Создайте надстройку для PowerPoint**
Вы также можете создать надстройку для Microsoft PowerPoint, которая обновляет все OLE объекты при открытии презентаций в программе.