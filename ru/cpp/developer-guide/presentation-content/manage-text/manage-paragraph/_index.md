---
title: Управление текстовыми абзацами PowerPoint в C++
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/cpp/manage-paragraph/
keywords:
- добавить текст
- добавить абзац
- управлять текстом
- управлять абзацем
- управлять маркером
- отступ абзаца
- висящий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспортировать абзац
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Освойте форматирование абзацев с помощью Aspose.Slides для C++ — оптимизируйте выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP на C++."
---

Aspose.Slides предоставляет все необходимые интерфейсы и классы для работы с текстами, абзацами и фрагментами PowerPoint в C++.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) , позволяющий добавлять объекты, представляющие абзац. Объект `ITextFame` может содержать один или несколько абзацев (каждый абзац создаётся с помощью символа возврата каретки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) , позволяющий добавлять объекты, представляющие фрагменты. Объект `IParagraph` может содержать один или несколько фрагментов (коллекция объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) , позволяющий добавлять объекты, представляющие тексты и их свойства форматирования. 

Объект `IParagraph` может обрабатывать тексты с различными свойствами форматирования через вложенные объекты `IPortion`.

## **Добавление нескольких абзацев, содержащих несколько фрагментов**

Эти шаги показывают, как добавить текстовый кадр, содержащий 3 абзаца, каждый из которых содержит 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте прямоугольную [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) для каждого нового `IParagraph` (по два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion соответствующего `IParagraph`.
7. Задайте некоторый текст для каждого фрагмента.
8. Примените желаемые параметры форматирования к каждому фрагменту, используя свойства форматирования, предоставляемые объектом `IPortion`.
9. Сохраните изменённую презентацию.

Этот код C++ реализует описанные шаги по добавлению абзацев, содержащих фрагменты: 
```c++
// Путь к каталогу документов.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Загрузите нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Добавьте TextFrame к прямоугольнику
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Доступ к первому абзацу
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

// Сохранить PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Управление маркерами абзацев**

Маркированные списки помогают быстро и эффективно упорядочить и представить информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) автокартины. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Установите свойство `Type` маркера для абзаца в значение `Symbol` и задайте символ маркера.
8. Задайте текст абзаца (`Text`).
9. Установите отступ абзаца (`Indent`) для маркера.
10. Задайте цвет маркера.
11. Задайте высоту маркера.
12. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
13. Добавьте второй абзац и повторите процесс, описанный в шагах 7‑13.
14. Сохраните презентацию.

Этот код C++ показывает, как добавить маркер абзаца:
```c++
// Путь к каталогу документов.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Загрузите нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Добавьте TextFrame к прямоугольнику
ashp->AddTextFrame(u"");

// Получение текстового фрейма
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Создайте объект Paragraph для текстового фрейма
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Установка текста
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Установка отступа маркера
paragraph->get_ParagraphFormat()->set_Indent (25);

// Установка цвета маркера
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Установка высоты маркера
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Добавление Paragraph в текстовый фрейм
txtFrame->get_Paragraphs()->Add(paragraph);

// Создание второго Paragraph
// Создайте объект Paragraph для текстового фрейма
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Установка текста
paragraph2->set_Text(u"This is numbered bullet");

// Установка типа и стиля маркера абзаца
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Установка отступа маркера
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Установка цвета маркера
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// установить IsBulletHardColor в true, чтобы использовать собственный цвет маркера
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Установка высоты маркера
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Добавление Paragraph в текстовый фрейм
txtFrame->get_Paragraphs()->Add(paragraph2);


// Сохранить PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Управление маркерами‑картинками**

Маркированные списки помогают быстро и эффективно упорядочить и представить информацию. Абзацы с картинками легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) автокартины. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца, используя класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/).
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) и задайте изображение.
9. Задайте текст абзаца (`Text`).
10. Установите отступ абзаца (`Indent`) для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, описанный в предыдущих шагах.
15. Сохраните изменённую презентацию.

Этот код C++ показывает, как добавить и управлять маркерами‑картинками:
```c++
// Создает экземпляр класса Presentation, представляющего файл PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Получает первый слайд
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Создает изображение для маркеров
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Добавляет и получает Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает текстовый фрейм автокартины
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Удаляет абзац по умолчанию
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Создает новый абзац
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Устанавливает стиль маркера абзаца и изображение
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Устанавливает высоту маркера
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Добавляет абзац в текстовый фрейм
paragraphs->Add(paragraph);

// Сохраняет презентацию как файл PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Сохраняет презентацию как файл PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```


## **Управление многоуровневыми маркерами**

Маркированные списки помогают быстро и эффективно упорядочить и представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) в новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) автокартины. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) и задайте глубину 0.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте глубину 1.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте глубину 2.
9. Создайте четвёртый экземпляр абзаца через класс `Paragraph` и задайте глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

Этот код C++ показывает, как добавить и управлять многоуровневыми маркерами:
```c++
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Получает первый слайд
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Добавляет и получает AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает текстовый фрейм созданного AutoShape
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Очищает абзац по умолчанию
text->get_Paragraphs()->Clear();

// Добавляет первый абзац
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
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
para2->set_Text(u"Second Level");
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
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Устанавливает уровень маркера
para3Format->set_Depth(2);

// Добавляет четвёртый абзац
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
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

// Сохраняет презентацию в файл PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```


## **Управление абзацем со пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) автокартины. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) и задайте [NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) равным 2.
7. Создайте второй экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 3.
8. Создайте третий экземпляр абзаца через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

Этот код C++ показывает, как добавить и управлять абзацами с пользовательской нумерацией или форматированием:
```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Доступ к текстовому фрейму созданного автокартины
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Удаляет существующий абзац по умолчанию
textFrame->get_Paragraphs()->RemoveAt(0);

// Первый список
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```


## **Установка отступа абзаца**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) класса.
1. Получите ссылку на соответствующий слайд по его индексу.
1. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) с тремя абзацами к прямоугольному автокарте.
1. Сскройте линии прямоугольника.
1. Установите отступ для каждого [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) через их свойство BulletOffset.
1. Запишите изменённую презентацию в файл PPT.

Этот код C++ показывает, как установить отступ абзаца: 
```c++
// Путь к каталогу документов.
const String outPath = u"../out/AddingSuperscriptAndSubscriptTextInTextFrame_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Загружает нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получает первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавляет AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Добавляет TextFrame к прямоугольнику
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

tf->get_Paragraphs()->Clear();

// Добавление первого абзаца
SharedPtr<Paragraph> superPar = MakeObject<Paragraph>();
SharedPtr<Portion> portion1 = MakeObject<Portion>(u"SlideTitle");
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

//Добавление в текстовый фрейм
ashp->get_TextFrame()->get_Paragraphs()->Add(superPar);
ashp->get_TextFrame()->get_Paragraphs()->Add(subPar);


// Сохраняет PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Установка висячего отступа для абзаца**

Этот код C++ показывает, как установить висячий отступ для абзаца:
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 250.0f, 550.0f, 150.0f);

System::SharedPtr<Paragraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Example");
System::SharedPtr<Paragraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Set Hanging Indent for Paragraph");
System::SharedPtr<Paragraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"This C# code shows you how to set the hanging indent for a paragraph: ");

para2->get_ParagraphFormat()->set_MarginLeft(10.f);
para3->get_ParagraphFormat()->set_MarginLeft(20.f);

auto paragraphs = autoShape->get_TextFrame()->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Управление свойствами End для абзаца**

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) класса.
1. Получите ссылку на слайд, содержащий абзац, через его позицию.
1. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
1. Добавьте [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) с двумя абзацами к прямоугольнику.
1. Установите `FontHeight` и тип шрифта для абзацев.
1. Установите свойства End для абзацев.
1. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как установить свойства End для абзацев в PowerPoint: 
```c++
// Путь к каталогу документов.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Load the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Access first slide
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Add an AutoShape of Rectangle type
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Add TextFrame to the Rectangle
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Adding the first Paragraph
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Adding the second Paragraph
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```


## **Импорт HTML‑текста в абзацы**

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) класса.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите `autoshape` [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) 
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML‑файл в TextReader.
7. Создайте первый экземпляр абзаца через класс [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) .
8. Добавьте содержимое HTML‑файла из прочитанного TextReader в [ParagraphCollection](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/) TextFrame.
9. Сохраните изменённую презентацию.

Этот код C++ реализует шаги по импорту HTML‑текстов в абзацы: 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Путь к каталогу документов.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Загрузите нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получите первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавьте AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Сброс цвета заливки по умолчанию
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Добавьте TextFrame к прямоугольнику
ashp->AddTextFrame(u" ");

// Доступ к текстовому фрейму
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Получить коллекцию Paragraphs
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Очистка всех абзацев в добавленном TextFrame
ParaCollection->Clear();

// Загрузка HTML‑файла с помощью StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Добавление текста из HTML‑потока в TextFrame
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Создать объект Paragraph для TextFrame
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Создать объект Portion для абзаца
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Получить формат Portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Установить шрифт для Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Установить свойство Bold (жирный) шрифта
pf->set_FontBold(NullableBool::True);

// Установить свойство Italic (курсив) шрифта
pf->set_FontItalic(NullableBool::True);

// Установить свойство Underline (подчёркнутый) шрифта
pf->set_FontUnderline(TextUnderlineType::Single);

// Установить высоту шрифта
pf->set_FontHeight(25);

// Установить цвет шрифта
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Сохранить PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```


## **Экспорт текста абзаца в HTML**

Aspose.Slides предоставляет расширенную поддержку экспорта текстов (содержащихся в абзацах) в HTML.

1. Создайте экземпляр [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на соответствующий слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите форму [TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) .
5. Создайте экземпляр `StreamWriter` и добавьте новый HTML‑файл.
6. Укажите начальный индекс для StreamWriter и экспортируйте выбранные абзацы.

Этот код C++ показывает, как экспортировать тексты абзацев PowerPoint в HTML: 
```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Путь к каталогу документов.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Загрузить нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Получить первый слайд презентации по умолчанию
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Требуемый индекс
int index = 0;

// Доступ к добавленной фигуре
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Извлечение первого абзаца в формате HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

//Writing Paragraphs data to HTML by providing paragraph starting index, total paragraphs to be copied
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```


## **Сохранение абзаца как изображения**

В этом разделе мы рассмотрим два примера, демонстрирующие, как сохранить текстовый абзац, представленный интерфейсом [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/), как изображение. Оба примера включают получение изображения формы, содержащей абзац, с помощью методов `GetImage` интерфейса [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/), вычисление границ абзаца внутри формы и экспорт его как bitmap‑изображения. Такие подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в разных сценариях.

Предположим, что у нас есть файл презентации sample.pptx с одним слайдом, где первая форма — это текстовое поле, содержащее три абзаца.

![Текстовый блок с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац в виде изображения. Для этого извлекаем изображение формы с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом кадре формы. Абзац затем перерисовывается на новом bitmap‑изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда нужно сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```


Результат:

![Изображение абзаца](paragraph_to_image_output.png)

**Пример 2**

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Форма извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить изображение более высокого разрешения при экспорте абзаца. Затем границы абзаца рассчитываются с учётом масштаба. Масштабирование может быть особенно полезно, когда требуется более детализированное изображение, например, для печатных материалов высокого качества.
```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```


## **FAQ**

**Можно ли полностью отключить перенос строк внутри текстового кадра?**

Да. Используйте метод переноса текста `[set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_wraptext/)` у текстового кадра, чтобы отключить перенос, тогда строки не будут разрываться у краёв кадра.

**Как получить точные границы конкретного абзаца на слайде?**

Можно получить прямоугольник, ограничивающий абзац (и даже отдельный фрагмент), чтобы знать его точное положение и размер на слайде.

**Где управляется выравнивание абзаца (по левому/правому/центру/ширине)?**

`[Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_alignment/)` — это настройка уровня абзаца в `[ParagraphFormat](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/)`; она применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Можно ли задать язык проверки орфографии только для части абзаца (например, одного слова)?**

Да. Язык задаётся на уровне фрагмента с помощью `[PortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/)`, поэтому в одном абзаце могут сосуществовать несколько языков.