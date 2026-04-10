---
title: Управление абзацами текста PowerPoint в C++
linktitle: Управление абзацем
type: docs
weight: 40
url: /ru/cpp/manage-paragraph/
keywords:
- добавить текст
- добавить абзац
- управление текстом
- управление абзацем
- управление маркером
- отступ абзаца
- висячий отступ
- маркер абзаца
- нумерованный список
- маркированный список
- свойства абзаца
- импорт HTML
- текст в HTML
- абзац в HTML
- абзац в изображение
- текст в изображение
- экспорт абзаца
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Освойте форматирование абзацев с Aspose.Slides для C++ — оптимизируйте выравнивание, интервалы и стиль в презентациях PPT, PPTX и ODP на C++."
---
Aspose.Slides предоставляет все интерфейсы и классы, необходимые для работы с текстами, абзацами и фрагментами PowerPoint в C++.

* Aspose.Slides предоставляет интерфейс [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) для добавления объектов, представляющих абзац. Объект `ITextFame` может содержать один или несколько абзацев (каждый абзац создаётся через возврат каретки).
* Aspose.Slides предоставляет интерфейс [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/) для добавления объектов, представляющих фрагменты. Объект `IParagraph` может содержать один или несколько фрагментов (коллекцию объектов iPortions).
* Aspose.Slides предоставляет интерфейс [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) для добавления объектов, представляющих тексты и их свойства форматирования. 

Объект `IParagraph` способен обрабатывать тексты с различными свойствами форматирования через свои вложенные объекты `IPortion`.

## **Добавление нескольких абзацев, содержащих несколько фрагментов**

Эти шаги показывают, как добавить текстовый кадр, содержащий 3 абзаца, каждый из которых содержит 3 фрагмента:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте прямоугольный [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите ITextFrame, связанный с [IAutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/).
5. Создайте два объекта [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/), и добавьте их в коллекцию `IParagraphs` объекта [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/).
6. Создайте три объекта [IPortion](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iportion/) для каждого нового `IParagraph` (по два объекта Portion для абзаца по умолчанию) и добавьте каждый объект `IPortion` в коллекцию IPortion соответствующего `IParagraph`.
7. Задайте некоторый текст для каждого фрагмента.
8. Примените желаемые свойства форматирования к каждому фрагменту с помощью свойств форматирования, доступных в объекте `IPortion`.
9. Сохраните изменённую презентацию.

Этот код C++ реализует шаги по добавлению абзацев с фрагментами: 

```c++
// Путь к каталогу документов.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Загрузить желаемую презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получить первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавить AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Добавить TextFrame к прямоугольнику
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Получение первого абзаца
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Adding second Paragraph
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Adding third Paragraph
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

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Управление маркерами абзацев**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Абзацы с маркерами всегда легче читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на выбранный слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) автоконтрола. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/).
7. Установите `Type` маркера для абзаца в значение `Symbol` и задайте символ маркера.
8. Задайте `Text` абзаца.
9. Установите `Indent` абзаца для маркера.
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

// Загрузить нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получить первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавить AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Добавить TextFrame к прямоугольнику
ashp->AddTextFrame(u"");

// Получение текстового кадра
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Создать объект Paragraph для текстового кадра
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Установка текста
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

// Добавление абзаца в текстовый кадр
txtFrame->get_Paragraphs()->Add(paragraph);

// Создание второго абзаца
// Создать объект Paragraph для текстового кадра
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Установка текста
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

// Добавление абзаца в текстовый кадр
txtFrame->get_Paragraphs()->Add(paragraph2);


// Сохранить PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Управление изображениями‑маркерами**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Абзацы с изображениями‑маркерами легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) автоконтрола. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый экземпляр абзаца с помощью класса [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/).
7. Загрузите изображение в [IPPImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/).
8. Установите тип маркера в [Picture](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ippimage/) и задайте изображение.
9. Задайте `Text` абзаца.
10. Установите `Indent` абзаца для маркера.
11. Задайте цвет маркера.
12. Задайте высоту маркера.
13. Добавьте новый абзац в коллекцию абзацев `TextFrame`.
14. Добавьте второй абзац и повторите процесс, основываясь на предыдущих шагах.
15. Сохраните изменённую презентацию.

Этот код C++ показывает, как добавить и управлять изображениями‑маркерами:

```c++
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Получает первый слайд
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Создаёт изображение для маркеров
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Добавляет и получает Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает TextFrame автоконтрола
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Удаляет абзац по умолчанию
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Создаёт новый абзац
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Устанавливает стиль маркера абзаца и изображение
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Устанавливает высоту маркера
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Добавляет абзац в TextFrame
paragraphs->Add(paragraph);

// Сохраняет презентацию как файл PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Сохраняет презентацию как файл PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Управление многоуровневыми маркерами**

Маркированные списки помогают быстро и эффективно организовать и представить информацию. Многоуровневые маркеры легко читать и понимать.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) в новый слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) автоконтрола. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый абзац через класс [Paragraph] и установите глубину 0.
7. Создайте второй абзац через класс `Paragraph` и установите глубину 1.
8. Создайте третий абзац через класс `Paragraph` и установите глубину 2.
9. Создайте четвёртый абзац через класс `Paragraph` и установите глубину 3.
10. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
11. Сохраните изменённую презентацию.

Этот код C++ показывает, как добавить и управлять многоуровневыми маркерами:

```c++
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Получает первый слайд
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Добавляет и получает Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает текстовый кадр созданного автоконтрола
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

// Добавляет четвертый абзац
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

// Сохраняет презентацию как файл PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Управление абзацем с пользовательским нумерованным списком**

Интерфейс [IBulletFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/) предоставляет свойство [NumberedBulletStartWith](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) и другие, позволяющие управлять абзацами с пользовательской нумерацией или форматированием. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите слайд, содержащий абзац.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) автоконтрола. 
5. Удалите абзац по умолчанию в `TextFrame`.
6. Создайте первый абзац через класс [Paragraph] и установите [NumberedBulletStartWith] в 2.
7. Создайте второй абзац через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 3.
8. Создайте третий абзац через класс `Paragraph` и задайте `NumberedBulletStartWith` равным 7.
9. Добавьте новые абзацы в коллекцию абзацев `TextFrame`.
10. Сохраните изменённую презентацию.

Этот код C++ показывает, как добавить и управлять абзацами с пользовательской нумерацией или форматированием:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Получает текстовый кадр созданного автоконтрола
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

## **Установка отступа первой строки для абзаца**

Используйте метод [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/) для управления отступом первой строки абзаца. Этот метод смещает только первую строку относительно левого поля абзаца. Положительное значение сдвигает первую строку вправо, остальные строки остаются выровненными по телу абзаца.

Используйте [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_marginleft/), когда нужно сдвинуть весь абзац. Используйте [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/), когда требуется сместить только первую строку.

Пример ниже создаёт несколько абзацев и применяет разные значения `Indent`, чтобы продемонстрировать, как отступ первой строки влияет на макет абзаца.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textframe/) к фигуре и удалите абзац по умолчанию.
5. Создайте несколько абзацев и задайте им разные значения [Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/).
6. Добавьте абзацы в текстовый кадр.
7. Сохраните изменённую презентацию.

Этот код показывает, как установить отступ абзаца:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Отступ первой строки абзацев](first_line_indent.png)

## **Установка висячего отступа для абзаца**

Висячий отступ — это макет абзаца, при котором первая строка начинается левее остальных строк. В Aspose.Slides вы создаёте такой эффект с помощью метода [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/). Установите отрицательное значение отступа, чтобы переместить первую строку влево относительно тела абзаца.

На практике [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_marginleft/) определяет левую позицию тела абзаца, а [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/) определяет позицию первой строки относительно этого поля. Чтобы создать висячий отступ, задайте положительное значение `MarginLeft` и отрицательное значение `Indent`.

Такое форматирование полезно для библиографий, ссылок, глоссариев и других абзацев, где перенесённые строки должны выравниваться под телом абзаца, а не под первым символом первой строки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите целевой слайд.
3. Добавьте прямоугольный [AutoShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/autoshape/) на слайд.
4. Добавьте пустой [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textframe/) к фигуре и удалите абзац по умолчанию.
5. Создайте абзацы и задайте каждому положительное значение [MarginLeft](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_marginleft/).
6. Задайте отрицательное значение [Indent](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraphformat/set_indent/), чтобы создать эффект висячего отступа.
7. Добавьте абзацы в текстовый кадр.
8. Сохраните изменённую презентацию.

Этот код показывает, как установить висячий отступ для абзаца:

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Результат:

![Висячий отступ абзацев](hanging_indent.png)

## **Управление свойствами End абзаца**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на слайд, содержащий абзац, по его позиции.
3. Добавьте прямоугольный [autoshape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Добавьте [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) с двумя абзацами к прямоугольнику.
5. Установите `FontHeight` и тип шрифта для абзацев.
6. Задайте свойства End для абзацев.
7. Запишите изменённую презентацию в файл PPTX.

Этот код C++ показывает, как задать свойства End для абзацев в PowerPoint: 

```c++
// Путь к каталогу документов.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Загрузить нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получить первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавить AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Добавить TextFrame к прямоугольнику
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Добавление первого абзаца
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Добавление второго абзаца
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Сохранить PPTX на диск
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Импорт HTML‑текста в абзацы**

Aspose.Slides предоставляет расширенную поддержку импорта HTML‑текста в абзацы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/).
2. Получите ссылку на нужный слайд по его индексу.
3. Добавьте [autoshape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iautoshape/) на слайд.
4. Добавьте и получите `autoshape` [ITextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) 
5. Удалите абзац по умолчанию в `ITextFrame`.
6. Прочитайте исходный HTML‑файл с помощью TextReader.
7. Создайте первый абзац через класс [Paragraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraph/).
8. Добавьте содержимое HTML‑файла, считанное TextReader, в [ParagraphCollection] TextFrame.
9. Сохраните изменённую презентацию.

Этот код C++ является реализацией шагов по импорту HTML‑текстов в абзацы: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Путь к каталогу документов.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Загрузить нужную презентацию
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Получить первый слайд
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Добавить AutoShape типа Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Сброс значения цвета заливки по умолчанию
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Добавить TextFrame к прямоугольнику
ashp->AddTextFrame(u" ");

// Получение текстового кадра
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Получить коллекцию Paragraphs
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Очистить все абзацы в добавленном текстовом кадре
ParaCollection->Clear();

// Загрузка HTML‑файла с помощью StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Добавление текста из HTML‑потока в текстовый кадр
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Создать объект Paragraph для текстового кадра
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Создать объект Portion для абзаца
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Получить формат Portion
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Установить шрифт для Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Установить свойство Bold для шрифта
pf->set_FontBold(NullableBool::True);

// Установить свойство Italic для шрифта
pf->set_FontItalic(NullableBool::True);

// Установить свойство Underline для шрифта
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

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) и загрузите нужную презентацию.
2. Получите ссылку на нужный слайд по его индексу.
3. Получите форму, содержащую текст, который будет экспортирован в HTML.
4. Получите [TextFrame](https://reference.aspose.com/slides/ru/cpp/aspose.slides/itextframe/) формы.
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

// Желаемый индекс
int index = 0;

// Доступ к добавленной фигуре
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Извлечение первого абзаца в виде HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Запись данных абзацев в HTML, указав начальный индекс абзаца и общее количество копируемых абзацев
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Сохранение абзаца как изображения**

В этом разделе мы рассмотрим два примера, демонстрирующих, как сохранить текстовый абзац, представленный интерфейсом [IParagraph](https://reference.aspose.com/slides/ru/cpp/aspose.slides/iparagraph/), как изображение. Оба примера включают получение изображения фигуры, содержащей абзац, с помощью методов `GetImage` из интерфейса [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/), вычисление границ абзаца внутри фигуры и экспорт его как растрового изображения. Такие подходы позволяют извлекать отдельные части текста из презентаций PowerPoint и сохранять их как отдельные изображения, что может быть полезно в разных сценариях.

Предположим, у нас есть файл презентации sample.pptx с одним слайдом, где первая фигура — это текстовое поле, содержащее три абзаца.

![Текстовое поле с тремя абзацами](paragraph_to_image_input.png)

**Пример 1**

В этом примере мы получаем второй абзац как изображение. Для этого извлекаем изображение фигуры с первого слайда презентации, затем вычисляем границы второго абзаца в текстовом кадре фигуры. Затем абзац перерисовывается на новом растровом изображении, которое сохраняется в формате PNG. Этот метод особенно полезен, когда нужно сохранить конкретный абзац как отдельное изображение, сохранив точные размеры и форматирование текста.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Сохранить фигуру в памяти как растровое изображение.
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

В этом примере мы расширяем предыдущий подход, добавляя коэффициенты масштабирования к изображению абзаца. Фигура извлекается из презентации и сохраняется как изображение с коэффициентом масштабирования `2`. Это позволяет получить изображение более высокого разрешения при экспорте абзаца. Затем границы абзаца рассчитываются с учётом масштаба. Масштабирование особенно полезно, когда требуется более детализированное изображение, например, для печати высокой качества.

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

**Могу ли я полностью отключить перенос строк внутри текстового кадра?**

Да. Используйте метод обтекания текстового кадра ([set_WrapText](https://reference.aspose.com/slides/ru/cpp/aspose.slides/textframeformat/set_wraptext/)), чтобы отключить перенос, и строки не будут разрываться у краёв кадра.

**Как получить точные границы конкретного абзаца на слайде?**

Вы можете получить ограничительный прямоугольник абзаца (и даже отдельного фрагмента), чтобы знать его точное положение и размер на слайде.

**Где контролируется выравнивание абзаца (по левому краю/правому/по центру/по ширине)?**

[Alignment](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraphformat/set_alignment/) — это настройка уровня абзаца в [ParagraphFormat](https://reference.aspose.com/slides/ru/cpp/aspose.slides/paragraphformat/); она применяется ко всему абзацу независимо от форматирования отдельных фрагментов.

**Могу ли я установить язык проверки орфографии только для части абзаца (например, для одного слова)?**

Да. Язык задаётся на уровне фрагмента с помощью ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/ru/cpp/aspose.slides/baseportionformat/set_languageid/)), поэтому в одном абзаце могут сосуществовать несколько языков.