---
title: Водяной знак
type: docs
weight: 40
url: /cpp/watermark/
keywords: "водяной знак в презентации"
description: "Используйте водяной знак в PowerPoint с Aspose.Slides. Добавьте водяной знак в ppt-презентацию или удалите водяной знак. Вставьте изображение водяного знака или текстовый водяной знак."
---

## **О водяном знаке**
**Водяной знак** в презентации — это текстовый или изображенческий штамп, используемый на слайде или на всех слайдах презентации. Обычно водяной знак используется, чтобы указать, что презентация является черновиком (например, водяной знак "Черновик"); что она содержит конфиденциальную информацию (например, водяной знак "Конфиденциально"); указать, к какой компании она принадлежит (например, водяной знак "Название компании"); идентифицировать автора презентации и т. д. Водяной знак помогает предотвратить нарушение авторских прав на презентацию, указывая, что презентацию нельзя копировать. Водяные знаки используются как в форматах презентаций PowerPoint, так и OpenOffice. В Aspose.Slides вы можете добавить водяной знак в форматы файлов PowerPoint PPT, PPTX и OpenOffice ODP.

В [**Aspose.Slides для C++**](https://products.aspose.com/slides/cpp/) есть разные способы создания водяного знака в PowerPoint или OpenOffice, обрамления его в различные формы, изменения дизайна и поведения и т. д. Общее заключается в том, что для добавления текстовых водяных знаков вам следует использовать класс [**TextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame), а для добавления изображенческого водяного знака - [**PictureFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.picture_frame). PictureFrame реализует интерфейс [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) и может использовать всю мощь гибких настроек объекта формы. TextFrame не является формой, и его настройки ограничены. Поэтому рекомендуется обрамлять TextFrame в объект [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape).

Существует два способа применения водяного знака: к отдельному слайду и ко всем слайдам презентации. Слайд-мастер используется для применения водяного знака ко всем слайдам презентации - водяной знак добавляется в Слайд-мастер, полностью проектируется там и применяется ко всем слайдам без изменения разрешения на редактирование водяного знака на слайдах.

Водяной знак обычно считается недоступным для редактирования другими пользователями. Чтобы предотвратить редактирование водяного знака (или, точнее, родительской формы водяного знака), Aspose.Slides предоставляет функциональность блокировки формы. Определенная форма может быть заблокирована на обычном слайде или на Слайд-мастере. Когда форма водяного знака заблокирована на Слайд-мастере, она будет заблокирована на всех слайдах презентации.

Вы можете задать имя водяного знака, чтобы в будущем, если вы захотите удалить водяной знак, вы могли найти его в формах слайда по имени.

Вы можете разрабатывать водяной знак любым способом; тем не менее, обычно есть некоторые общие характеристики водяных знаков, такие как: центрирование, поворот, передняя позиция и т. д. Мы рассмотрим, как их использовать в следующих примерах.
## **Текстовый водяной знак**
### **Добавить текстовый водяной знак на слайд**
Чтобы добавить текстовый водяной знак в PPT, PPTX или ODP, вы можете сначала добавить форму на слайд, затем добавить текстовый фрейм в эту форму. Текстовый фрейм представлен типом [**TextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame). Этот тип не наследует [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape), у которого широкий набор свойств для гибкой настройки водяного знака. Поэтому рекомендуется обрамлять объект [TextFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame) в объект [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape). Чтобы добавить водяной знак в форму, используйте метод [**AddTextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3) с текстом водяного знака, переданным в него:

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

auto master = presentation->get_Masters()->idx_get(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 0.0f, 0.0f, 0.0f, 0.0f);

auto watermarkTextFrame = watermarkShape->AddTextFrame(u"Водяной знак");
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/cpp/slide-master/)[TextFrame](/slides/cpp/adding-and-formatting-text/)
{{% /alert %}}

### **Добавить текстовый водяной знак в презентацию**
Если вы хотите добавить водяной знак в презентацию (то есть на все слайды сразу), добавьте его в [**MasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.master_slide). Вся другая логика остается такой же, как и при добавлении водяного знака на отдельный слайд - создайте объект [IAutoShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape) и затем добавьте водяной знак в него с помощью метода [**AddTextFrame**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3):

``` cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

auto master = presentation->get_Masters()->idx_get(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 0.0f, 0.0f, 0.0f, 0.0f);

auto watermarkTextFrame = watermarkShape->AddTextFrame(u"Водяной знак");
```


{{% alert color="primary" title="Смотрите также" %}} 
- [Как использовать ](/slides/cpp/slide-master/)[Слайд-мастер](/slides/cpp/slide-master/)
{{% /alert %}}

### **Установить шрифт текстового водяного знака**
Вы можете изменить шрифт текстового водяного знака:

``` cpp
int32_t alpha = 150, red = 200, green = 200, blue = 200;
    
auto watermarkPortion = watermarkTextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);

watermarkPortion->get_PortionFormat()->set_FontHeight(52.0f);
```


### **Установить прозрачность текстового водяного знака**
Чтобы установить прозрачность текстового водяного знака, используйте этот код:

``` cpp
int32_t alpha = 150, red = 200, green = 200, blue = 200;
    
auto watermarkPortion = watermarkTextFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);

watermarkPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);

watermarkPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```


### **Центрировать текстовый водяной знак**
Можно центрировать водяной знак на слайде, и для этого вы можете сделать следующее:

``` cpp
PointF center(presentation->get_SlideSize()->get_Size().get_Width() / 2, presentation->get_SlideSize()->get_Size().get_Height() / 2);

float width = 300.0f;
float height = 300.0f;

float x = center.get_X() - width / 2;
float y = center.get_Y() - height / 2;

//...

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, x, y, width, height);
```


## **Изображенческий водяной знак**
### **Добавить изображенческий водяной знак в презентацию**
Чтобы добавить изображенческий водяной знак на все слайды презентации, вы можете сделать следующее:

``` cpp
auto image = presentation->get_Images()->AddImage(:File::ReadAllBytes(u"watermark.png"));

// ...

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);

watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```




## **Блокировка водяного знака от редактирования**
Если нужно предотвратить редактирование водяного знака, используйте метод [**AutoShape::get_AutoShapeLock()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape#a3493d7814106e74ef2213707f64135a8) на форме, которая обрамляет его. С помощью этого метода вы можете защитить форму от выделения, изменения размера, изменения положения, группировки с другими элементами, заблокировать его текст от редактирования и многое другое:

``` cpp
// Заблокировать формы от модификации
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```



{{% alert color="primary" title="Смотрите также" %}} 
- [Как заблокировать формы от редактирования](/slides/cpp/presentation-locking/)
{{% /alert %}}

## **Переместить водяной знак на передний план**
В Aspose.Slides порядок Z-форм может быть установлен с помощью метода [**SlideCollection::Reorder()** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad9bc39c557ea8ea3d67e8cec53363c40). Для этого вам нужно вызвать этот метод из списка слайдов презентации и передать ссылку на форму и ее номер порядка в метод. Таким образом возможно поместить форму на передний план или на задний план слайда. Эта функция особенно полезна, если вам нужно разместить водяной знак на переднем плане презентации:

``` cpp
slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, watermarkShape);
```


## **Установить поворот водяного знака**
Вот пример, как установить поворот водяного знака (и его родительской формы):

``` cpp
int32_t calculateRotation(float height, float width)
{
    double pageHeight = Convert::ToDouble(height);
    double pageWidth = Convert::ToDouble(width);
    
    double rotation = Math::Atan((pageHeight / pageWidth)) * 180 / Math::PI;
    
    return Convert::ToInt32(rotation);
}
```

``` cpp
float h = presentation->get_SlideSize()->get_Size().get_Height();
float w = presentation->get_SlideSize()->get_Size().get_Width();

watermarkShape->set_X(static_cast<float>(System::Convert::ToInt32((w - watermarkShape->get_Width()) / 2)));

watermarkShape->set_Y(static_cast<float>(System::Convert::ToInt32((h - watermarkShape->get_Height()) / 2)));

watermarkShape->set_Rotation(static_cast<float>(calculateRotation(h, w)));
```


## **Установить имя для водяного знака**
Aspose.Slides позволяет задавать имя формы. По имени формы вы можете получить к ней доступ в будущем для модификации или удаления. Чтобы установить имя родительской формы водяного знака, задайте его в методе [**AutoShape::set_Name()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape#ab3df67c6a42fb153d84f58ee69e8b221):

``` cpp
watermarkShape->set_Name(u"водяной знак");
```


## **Удалить водяной знак**
Чтобы удалить форму водяного знака и ее дочерние элементы с слайда, используйте метод [AutoShape.get_Name()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape#a3de41f504e4f9a728c3801159773487e) для поиска ее в формах слайда. Затем передайте форму водяного знака в метод [**ShapeCollection::Remove()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape_collection#a78968527e6f86cced3ffa5c2accab3fc):

``` cpp
for (int32_t i = 0; i < slide->get_Shapes()->get_Count(); i++)
{
	auto shape = ExplicitCast<AutoShape>(slide->get_Shapes()->idx_get(i));
	if (String::Compare(shape->get_Name(), u"водяной знак", StringComparison::Ordinal) == 0)
	{
		slide->get_Shapes()->Remove(watermarkShape);
	}
}
```


## **Пример в реальном времени**
Вам может быть интересно ознакомиться с **Aspose.Slides** **бесплатными** [**Добавить водяной знак** ](https://products.aspose.app/slides/watermark) и [**Удалить водяной знак**](https://products.aspose.app/slides/watermark/remove-watermark) онлайн инструментами.

![todo:image_alt_text](slides-watermark.png)