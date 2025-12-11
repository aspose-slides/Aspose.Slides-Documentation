---
title: Добавление водяных знаков в презентации на C++
linktitle: Водяной знак
type: docs
weight: 40
url: /ru/cpp/watermark/
keywords:
- водяной знак
- текстовый водяной знак
- графический водяной знак
- добавить водяной знак
- изменить водяной знак
- удалить водяной знак
- удалить водяной знак
- добавить водяной знак в PPT
- добавить водяной знак в PPTX
- добавить водяной знак в ODP
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- удалить водяной знак из PPT
- удалить водяной знак из PPTX
- удалить водяной знак из ODP
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Управляйте текстовыми и графическими водяными знаками в презентациях PowerPoint и OpenDocument на C++, чтобы указывать черновик, конфиденциальную информацию, авторские права и многое другое."
---

## **Обзор**

**Водяной знак** в презентации — это текстовый или графический штамп, используемый на отдельном слайде или на всех слайдах презентации. Обычно водяной знак применяется, чтобы указать, что презентация является черновиком (например, водяной знак «Черновик»), содержит конфиденциальную информацию (например, водяной знак «Конфиденциально»), принадлежит определённой компании (например, водяной знак «Название компании»), идентифицировать автора презентации и т.д. Водяной знак помогает предотвратить нарушения авторских прав, указывая, что презентацию нельзя копировать. Водяные знаки используются как в форматах PowerPoint, так и в OpenOffice. В Aspose.Slides вы можете добавить водяной знак в файлы PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides**](https://products.aspose.com/slides/cpp/) существуют различные способы создания водяных знаков в PowerPoint или OpenOffice‑документах и изменения их дизайна и поведения. Общий момент заключается в том, что для добавления текстовых водяных знаков следует использовать интерфейс [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), а для добавления графических водяных знаков — класс [PictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/pictureframe/) либо заполнить форму водяного знака изображением. `PictureFrame` реализует интерфейс [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), позволяя использовать все гибкие настройки объекта формы. Поскольку `ITextFrame` не является формой и его параметры ограничены, он оборачивается в объект [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/).

Существует два способа применения водяного знака: к отдельному слайду или ко всем слайдам презентации. Slide Master используется для применения водяного знака ко всем слайдам — водяной знак добавляется в Slide Master, полностью оформляется там и применяется ко всем слайдам без ограничения возможности изменения водяного знака на отдельных слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (а точнее родительской формы водяного знака), Aspose.Slides предоставляет функцию блокировки формы. Конкретную форму можно заблокировать на обычном слайде или на Slide Master. Когда форма водяного знака заблокирована на Slide Master, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя для водяного знака, чтобы в будущем, при необходимости удаления, найти его в списке форм слайда по имени.

Вы можете оформить водяной знак произвольно; однако обычно водяные знаки имеют общие черты, такие как центрирование, вращение, размещение спереди и т.д. Мы рассмотрим, как использовать эти возможности в примерах ниже.

## **Текстовый водяной знак**

### **Добавление текстового водяного знака на слайд**

Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, сначала добавьте форму на слайд, затем добавьте в эту форму текстовый кадр. Текстовый кадр представлен интерфейсом [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). Этот тип не наследуется от [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), который обладает широким набором свойств для гибкой позиционирования водяного знака. Поэтому объект [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) оборачивается в объект [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/). Чтобы добавить текст водяного знака в форму, используйте метод [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/) как показано ниже.
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="См. также" %}} 
- [Как использовать класс TextFrame](/slides/ru/cpp/text-formatting/)
{{% /alert %}}

### **Добавление текстового водяного знака в презентацию**

Если требуется добавить текстовый водяной знак ко всей презентации (то есть сразу на все слайды), добавьте его в [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/). Остальная логика аналогична добавлению водяного знака на отдельный слайд — создайте объект [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) и затем добавьте к нему водяной знак с помощью метода [AddTextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/addtextframe/).
```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```


{{% alert color="primary" title="См. также" %}} 
- [Как использовать Slide Master](/slides/ru/cpp/slide-master/)
{{% /alert %}}

### **Установка прозрачности формы водяного знака**

По умолчанию прямоугольная форма оформлена заливкой и цветом линии. Следующий код делает форму прозрачной.
```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```


### **Установка шрифта для текстового водяного знака**

Вы можете изменить шрифт текстового водяного знака, как показано ниже.
```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```


### **Установка цвета текста водяного знака**

Чтобы задать цвет текста водяного знака, используйте следующий код:
```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **Центрирование текстового водяного знака**

Возможно центрировать водяной знак на слайде, для чего выполните следующее:
```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```


Ниже показан окончательный результат.

![Текстовый водяной знак](text_watermark.png)

## **Графический водяной знак**

### **Добавление графического водяного знака в презентацию**

Чтобы добавить графический водяной знак на слайд презентации, выполните следующее:
```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```


## **Блокировка водяного знака от редактирования**

Если необходимо запретить редактирование водяного знака, используйте метод [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_autoshapelock/) у формы. С помощью этого свойства можно защитить форму от выбора, изменения размера, перемещения, группировки с другими элементами, блокировать её текст от редактирования и многое другое:
```cpp
// Заблокировать форму водяного знака от изменения
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```


## **Перемещение водяного знака на передний план**

В Aspose.Slides порядок наложения форм можно задать через метод [IShapeCollection::Reorder](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/reorder/). Для этого вызовите метод из списка слайдов презентации, передав в него ссылку на форму и её порядковый номер. Таким образом можно переместить форму на передний план или отправить её на задний план слайда. Эта возможность особенно полезна, если необходимо разместить водяной знак перед содержимым презентации:
```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```


## **Установка вращения водяного знака**

Ниже пример кода, показывающего, как отрегулировать вращение водяного знака, чтобы он располагался по диагонали слайда:
```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```


## **Задание имени для водяного знака**

Aspose.Slides позволяет задать имя форме. Используя имя формы, вы сможете в дальнейшем получить к ней доступ для изменения или удаления. Чтобы задать имя форме водяного знака, присвойте его методу [IAutoShape::set_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_name/):
```cpp
watermarkShape->set_Name(u"watermark");
```


## **Удаление водяного знака**

Чтобы удалить форму водяного знака, используйте метод [IAutoShape::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_name/) для поиска её среди форм слайда. Затем передайте найденную форму в метод [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/):
```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```


## **Рабочий пример**

Вы можете ознакомиться с бесплатными онлайн‑инструментами Aspose.Slides **Add Watermark**[https://products.aspose.app/slides/watermark] и **Remove Watermark**[https://products.aspose.app/slides/watermark/remove-watermark].

![Онлайн‑инструменты для добавления и удаления водяных знаков](online_tools.png)

## **FAQ**

**Что такое водяной знак и зачем он нужен?**

Водяной знак — это наложение текста или изображения на слайды, которое помогает защитить интеллектуальную собственность, усилить узнаваемость бренда или предотвратить несанкционированное использование презентаций.

**Могу ли я добавить водяной знак на все слайды презентации?**

Да, Aspose.Slides позволяет программно добавить водяной знак на каждый слайд презентации. Вы можете перебрать все слайды и применить настройки водяного знака к каждому из них.

**Как изменить прозрачность водяного знака?**

Прозрачность водяного знака регулируется изменением параметров заливки ([FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_fillformat/)) формы. Это обеспечивает тонкое отображение водяного знака без отвлечения внимания от содержимого слайда.

**Какие форматы изображений поддерживаются для водяных знаков?**

Aspose.Slides поддерживает различные форматы изображений, такие как PNG, JPEG, GIF, BMP, SVG и др.

**Можно ли настроить шрифт и стиль текстового водяного знака?**

Да, вы можете выбрать любой шрифт, размер и стиль, чтобы они соответствовали дизайну вашей презентации и поддерживали единообразие бренда.

**Как изменить позицию или ориентацию водяного знака?**

Позицию и ориентацию водяного знака можно программно изменить, изменяя координаты, размер и свойства вращения формы.