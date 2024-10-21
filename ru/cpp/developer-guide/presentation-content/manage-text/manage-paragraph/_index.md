---
title: Управление абзацем PowerPoint в C++
type: docs
weight: 40
url: /ru/cpp/manage-paragraph/
keywords: "Добавить абзац PowerPoint, Управлять абзацами, Отступ абзаца, Свойства абзаца, HTML текст, Экспорт текста абзаца, Презентация PowerPoint, C++, CPP, Aspose.Slides для C++"
description: "Создавайте и управляйте абзацем, текстом, отступом и свойствами в презентациях PowerPoint на C++"
---

Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и частями в PowerPoint на C++.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/), который позволяет добавлять объекты, представляющие абзац. Объект `ITextFame` может содержать один или несколько абзацев (каждый абзац создается с помощью переноса строки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/), который позволяет добавлять объекты, представляющие части. Объект `IParagraph` может содержать одну или несколько частей (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/), который позволяет добавлять объекты, представляющие текст и их свойства форматирования.

Объект `IParagraph` способен обрабатывать тексты с различными свойствами форматирования через свои базовые объекты `IPortion`.

## **Добавить несколько абзацев, содержащих несколько частей**

Эти шаги демонстрируют, как добавить текстовый фрейм, содержащий 3 абзаца, и каждый абзац — 3 части:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте фигуру Прямоугольник [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите `ITextFrame`, связанный с [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` класса [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) для каждого нового `IParagraph` (два объекта Portion для стандартного абзаца) и добавьте каждый объект `IPortion` в коллекцию IPortion каждого `IParagraph`.
7. Установите некоторый текст для каждой части.
8. Примените предпочитаемые функции форматирования к каждой части с использованием свойств форматирования, предоставленных объектом `IPortion`.
9. Сохраните измененную презентацию.

Этот код на C++ является реализацией шагов добавления абзацев, содержащих части: 

```c++
// Путь к каталогу документов.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Загрузите желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте автофигуру типа Прямоугольник
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Добавьте текстовый фрейм к прямоугольнику
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Получение первого абзаца
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Добавление второго абзаца
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Добавление третьего абзаца
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Сохраните PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Управление маркировкой абзацев**

Нумерованные списки помогают быстро и эффективно организовывать и представлять информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на выбранный слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) автофигуры. 
5. Удалите стандартный абзац в `TextFrame`.
6. Создайте экземпляр первого абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Установите `Type` маркера для абзаца на `Symbol` и задайте символ маркера.
8. Установите `Text` абзаца.
9. Установите `Indent` абзаца для маркера.
10. Задайте цвет для маркера.
11. Установите высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, указанный в шагах 7–13.
14. Сохраните презентацию.

Этот код на C++ показывает, как добавить маркер абзаца:

```c++
// Путь к каталогу документов.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Загрузите желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте автофигуру типа Прямоугольник
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Добавьте текстовый фрейм к прямоугольнику
ashp->AddTextFrame(u"");

// Получение текстового фрейма
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Создайте объект абзаца для текстового фрейма
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Установка текста
paragraph->set_Text(u"Добро пожаловать в Aspose.Slides");

// Установите отступ маркера
paragraph->get_ParagraphFormat()->set_Indent (25);

// Установите цвет маркера
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// Установите IsBulletHardColor в true, чтобы использовать свой цвет маркера
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Установите высоту маркера
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Добавление абзаца в текстовый фрейм
txtFrame->get_Paragraphs()->Add(paragraph);

// Создание второго абзаца
// Создайте объект абзаца для текстового фрейма
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Установка текста
paragraph2->set_Text(u"Это нумерованный маркер");

// Установите тип и стиль маркера для абзаца
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Установите отступ маркера
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Установите цвет маркера
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// Установите IsBulletHardColor в true, чтобы использовать свой цвет маркера
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Установите высоту маркера
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Добавление абзаца в текстовый фрейм
txtFrame->get_Paragraphs()->Add(paragraph2);


// Сохраните PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Управление изображениями маркеров**

Списки с маркерами помогают быстро и эффективно организовывать и представлять информацию. Абзацы с изображениями легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) автофигуры. 
5. Удалите стандартный абзац в `TextFrame`.
6. Создайте экземпляр первого абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Установите тип маркера на [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) и задайте изображение.
9. Установите `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Установите цвет для маркера.
12. Установите высоту для маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс на основе предыдущих шагов.
15. Сохраните измененную презентацию.

Этот код на C++ показывает, как добавить и управлять маркерами изображений:

```c++
// Создает класс Presentation, который представляет файл PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Получает первый слайд
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Создает изображение для маркеров
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Добавляет и получает автофигуру
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает текстовый фрейм автофигуры
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Удаляет стандартный абзац
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Создает новый абзац
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Добро пожаловать в Aspose.Slides");

// Устанавливает стиль и изображение маркера абзаца
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Устанавливает высоту маркера
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Добавляет абзац в текстовый фрейм
paragraphs->Add(paragraph);

// Записывает презентацию как файл PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Записывает презентацию как файл PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Управление многоуровневыми маркерами**

Списки с маркерами помогают быстро и эффективно организовывать и представлять информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на новый слайд.
4. Доступ к [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) автофигуры. 
5. Удалите стандартный абзац в `TextFrame`.
6. Создайте экземпляр первого абзаца через класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте экземпляр второго абзаца через класс `Paragraph` и задайте глубину 1.
8. Создайте экземпляр третьего абзаца через класс `Paragraph` и задайте глубину 2.
9. Создайте экземпляр четвертого абзаца через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните измененную презентацию.

Этот код на C++ показывает, как добавить и управлять многоуровневыми маркерами:

```c++
// Создает класс Presentation, который представляет файл PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Получает первый слайд
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Добавляет и получает автофигуру
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает текстовый фрейм созданной автофигуры
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Очищает стандартный абзац
text->get_Paragraphs()->Clear();

// Добавляет первый абзац
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Содержимое");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Устанавливает уровень маркера
para1Format->set_Depth(0);

// Добавляет второй абзац
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Второй уровень");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Устанавливает уровень маркера
para2Format->set_Depth(1);

// Добавляет третий абзац
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Третий уровень");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Устанавливает уровень маркера
para3Format->set_Depth(2);

// Добавляет четвертый абзац
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Четвертый уровень");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Устанавливает уровень маркера
para4Format->set_Depth(3);

// Добавляет абзацы в коллекцию
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Записывает презентацию как файл PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Управление абзацем с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) и другие, которые позволяют управлять абзацами с пользовательским номерованием или форматированием. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Доступ к автофигуре [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/). 
5. Удалите стандартный абзац в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) и установите [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) на 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и установите `NumberedBulletStartWith` на 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните измененную презентацию.

Этот код на C++ показывает, как добавить и управлять абзацами с пользовательским номерованием или форматированием:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает текстовый фрейм созданной автофигуры
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Удаляет стандартный имеющийся абзац
textFrame->get_Paragraphs()->RemoveAt(0);

// Первый список
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"маркер 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"маркер 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"маркер 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **Установить отступ абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на соответствующий слайд по его индексу.
1. Добавьте прямоугольную [автофигуру](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) с тремя абзацами в прямоугольной автофигуре.
1. Скрытие линий прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) через свойство BulletOffset.
1. Запишите измененную презентацию как файл PPTX.

Этот код на C++ показывает, как установить отступ для абзаца: 

```c++
// Путь к каталогу документов.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Загрузите желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте автофигуру типа Прямоугольник
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Добавьте текстовый фрейм к прямоугольнику
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Добавление первого абзаца
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"ЗаголовокСлайда");
superPar->get_Portions()->Add(portion1);

SharedPtr<Portion> superPortion = MakeObject<Portion>();
superPortion->get_PortionFormat()->set_Escapement(30);
superPortion->set_Text(u"TM");
superPar->get_Portions()->Add(superPortion);


// Добавление первого абзаца
SharedPtr<Paragraph> subPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion2 = MakeObject<Portion>(u"a");
subPar->get_Portions()->Add(portion2);

SharedPtr<Portion> subPortion = MakeObject<Portion>();
subPortion->get_PortionFormat()->set_Escapement(-25);
subPortion->set_Text(u"i");
subPar->get_Portions()->Add(subPortion);

// Добавление в текстовый фрейм
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Сохраните PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Установить висячий отступ для абзаца**

Этот код на C++ показывает, как установить висячий отступ для абзаца:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Пример");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Установить висячий отступ для абзаца");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Этот код C# показывает, как установить висячий отступ для абзаца: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Управление свойствами конечного абзаца для абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Получите ссылку на слайд, содержащий абзац, по его позиции.
1. Добавьте прямоугольную [автофигуру](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) с двумя абзацами в прямоугольнике.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Установите конечные свойства для абзацев.
1. Запишите измененную презентацию как файл PPTX.

Этот код на C++ показывает, как установить конечные свойства для абзацев в PowerPoint: 

```c++
// Путь к каталогу документов.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Загрузите желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте автофигуру типа Прямоугольник
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Добавьте текстовый фрейм к прямоугольнику
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Добавление первого абзаца
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Пример текста");

para1->get_Portions()->Add(port01);

// Добавление второго абзаца
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Пример текста 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Сохраните PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Импорт HTML текста в абзацы**

Aspose.Slides предоставляет улучшенную поддержку для импорта HTML текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [автофигуру](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите `автофигуру` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. Удалите стандартный абзац в `ITextFrame`.
6. Прочтите исходный HTML файл в TextReader.
7. Создайте экземпляр первого абзаца через класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
8. Добавьте содержимое HTML файла в прочитанном TextReader в коллекцию [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните измененную презентацию.

Этот код на C++ является реализацией шагов по импорту HTML текста в абзацы: 

```c++
Для полных примеров и файлов данных, пожалуйста, перейдите на https://github.com/aspose-slides/Aspose.Slides-for-C
// Путь к каталогу документов.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Загрузите желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте автофигуру типа Прямоугольник
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Сброс цвета заливки по умолчанию
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Добавьте текстовый фрейм к прямоугольнику
ashp->AddTextFrame(u" ");

// Получение текстового фрейма
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Получите коллекцию абзацев
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Очистка всех абзацев в добавленном текстовом фрейме
ParaCollection->Clear();

// Загрузка HTML файла с помощью потока чтения
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Добавление текста из потока HTML в текстовый фрейм
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Создайте объект абзаца для текстового фрейма
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Создайте объект Portion для абзаца
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Получите формат части
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Установите шрифт для части
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Установите свойство жирности шрифта
pf->set_FontBold(NullableBool::True);

// Установите свойство курсивности шрифта
pf->set_FontItalic(NullableBool::True);

// Установите свойство подчеркивания шрифта
pf->set_FontUnderline(TextUnderlineType::Single);

// Установите высоту шрифта
pf->set_FontHeight(25);

// Установите цвет шрифта
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Сохраните PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```


## **Экспорт текста абзацев в HTML**

Aspose.Slides предоставляет улучшенную поддержку для экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и загрузите желаемую презентацию.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите фигуру, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) фигуры.
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте предпочитаемые абзацы.

Этот код на C++ показывает, как экспортировать текст абзацев PowerPoint в HTML: 

```c++
Для полных примеров и файлов данных, пожалуйста, перейдите на https://github.com/aspose-slides/Aspose.Slides-for-C
// Путь к каталогу документов.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Загрузите желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Доступ к стандартному первому слайду презентации
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Желаемый индекс
int index = 0;

// Получение добавленной фигуры
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Извлечение первого абзаца как HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Запись данных абзацев в HTML, предоставляя индекс начала абзаца, общее количество абзацев для копирования
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```