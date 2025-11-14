---
title: Управляйте текстовыми полями в презентациях с помощью Python
linktitle: Управление текстовым полем
type: docs
weight: 20
url: /ru/python-net/manage-textbox/
keywords:
- текстовое поле
- текстовая рамка
- добавление текста
- обновление текста
- создание текстового поля
- проверка текстового поля
- добавление текстовой колонки
- добавление гиперссылки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET упрощает создание, редактирование и клонирование текстовых полей в файлах PowerPoint и OpenDocument, повышая эффективность автоматизации презентаций."
---

Тексты на слайдах обычно находятся в текстовых полях или формах. Поэтому, чтобы добавить текст на слайд, вам нужно добавить текстовое поле и затем поместить текст внутрь текстового поля. Aspose.Slides для Python через .NET предоставляет интерфейс [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/), который позволяет добавлять фигуры, содержащие текст.

{{% alert title="Информация" color="info" %}}

Aspose.Slides также предоставляет интерфейс [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), который позволяет добавлять фигуры на слайды. Тем не менее, не все фигуры, добавленные через интерфейс `IShape`, могут содержать текст. Однако фигуры, добавленные через интерфейс [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/), могут содержать текст.

{{% /alert %}}

{{% alert title="Примечание" color="warning" %}} 

Поэтому, работая с фигурой, к которой вы хотите добавить текст, вам следует проверить и подтвердить, что она была приведена через интерфейс `IAutoShape`. Только тогда вы сможете работать с [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/), который является свойством интерфейса `IAutoShape`. См. раздел [Обновить текст](https://docs.aspose.com/slides/python-net/manage-textbox/#update-text) на этой странице. 

{{% /alert %}}

## **Создание текстового поля на слайде**

Чтобы создать текстовое поле на слайде, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) с установленным [ShapeType](https://reference.aspose.com/slides/python-net/aspose.slides/igeometryshape/) как `RECTANGLE` в указанной позиции на слайде и получите ссылку на только что добавленный объект `IAutoShape`. 
4. Добавьте свойство `text_frame` к объекту `IAutoShape`, которое будет содержать текст. В примере ниже мы добавили этот текст: *Aspose TextBox*
5. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код на Python — реализация вышеописанных шагов — показывает, как добавить текст на слайд:

```py
import aspose.slides as slides

# Создает экземпляр PresentationEx
with slides.Presentation() as pres:

    # Получает первый слайд в презентации
    sld = pres.slides[0]

    # Добавляет AutoShape с типом, установленным как Rectangle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Добавляет TextFrame в Rectangle
    ashp.add_text_frame(" ")

    # Получает доступ к текстовому фрейму
    txtFrame = ashp.text_frame

    # Создает объект Paragraph для текстового фрейма
    para = txtFrame.paragraphs[0]

    # Создает объект Portion для абзаца
    portion = para.portions[0]

    # Устанавливает текст
    portion.text = "Aspose TextBox"

    # Сохраняет презентацию на диск
    pres.save("TextBox_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Проверка фигуры текстового поля**

Aspose.Slides предоставляет свойство `is_text_box` (из класса [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)), чтобы вы могли проверять фигуры и находить текстовые поля.

![Текстовое поле и фигура](istextbox.png)

Этот код на Python показывает, как проверить, было ли создано фигура как текстовое поле: xxx

```python
from aspose.slides import Presentation, AutoShape

with Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if (type(shape) is AutoShape):
                print("фигура является текстовым полем" if shape.is_text_box else "фигура не является текстовым полем")
```

## **Добавление столбца в текстовое поле**

Aspose.Slides предоставляет свойства [column_count](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) и [column_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) и класса [text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/)), которые позволяют добавлять столбцы в текстовые поля. Вы можете указать количество столбцов в текстовом поле и установить пространство между столбцами в пунктах. 

Этот код на Python демонстрирует описанную операцию: 

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	# Получает первый слайд в презентации
	slide = presentation.slides[0]

	# Добавляет AutoShape с типом, установленным как Rectangle
	aShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# Добавляет TextFrame в Rectangle
	aShape.add_text_frame("Все эти столбцы ограничены одним текстовым контейнером -- " +
	"вы можете добавлять или удалять текст, и новый или оставшийся текст автоматически подстраивается " +
	"внутри контейнера. Вы не можете перенаправить текст из одного контейнера " +
	"в другой, хотя -- мы говорили вам, что возможности PowerPoint для текстовых колонок ограничены!")

	# Получает текстовый формат TextFrame
	format = aShape.text_frame.text_frame_format

	# Указывает количество столбцов в TextFrame
	format.column_count = 3

	# Указывает пространство между столбцами
	format.column_spacing = 10

	# Сохраняет презентацию
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление столбца в текстовый фрейм**
Aspose.Slides для Python через .NET предоставляет свойство [ColumnCount](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/) (из интерфейса [ITextFrameFormat](https://reference.aspose.com/slides/python-net/aspose.slides/itextframeformat/)), которое позволяет добавлять столбцы в текстовые фреймы. Через это свойство вы можете указать предпочитаемое количество столбцов в текстовом фрейме. 

 Этот код на Python показывает, как добавить столбец внутри текстового фрейма:

```py
import aspose.slides as slides

outPptxFileName = "ColumnsTest.pptx"
with slides.Presentation() as pres:
    shape1 = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)
    format = shape1.text_frame.text_frame_format

    format.column_count = 2
    shape1.text_frame.text = """Все эти столбцы заставляют оставаться в одном текстовом контейнере -- 
        вы можете добавлять или удалять текст - и новый или оставшийся текст автоматически подстраивается 
        внутри контейнера. Вы не можете перенаправить текст из одного контейнера 
        в другой, хотя -- потому что возможности PowerPoint для текстовых колонок ограничены!
        pres.save(outPptxFileName, slides.export.SaveFormat.PPTX)"""

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_spacing = 20
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)

    format.column_count = 3
    format.column_spacing = 15
    pres.save(path + outPptxFileName, slides.export.SaveFormat.PPTX)

    with slides.Presentation(path + outPptxFileName) as test:
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_count)
        print(test.slides[0].shapes[0].text_frame.text_frame_format.column_spacing)
```

## **Обновление текста**

Aspose.Slides позволяет изменять или обновлять текст, содержащийся в текстовом поле, или все тексты, содержащиеся в презентации. 

Этот код на Python демонстрирует операцию, в которой все тексты в презентации обновляются или изменяются:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # Сохраняет измененную презентацию
    pres.save("text-changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Добавление текстового поля с гиперссылкой** 

Вы можете вставить ссылку внутрь текстового поля. При нажатии на текстовое поле пользователи перенаправляются для открытия ссылки. 

 Чтобы добавить текстовое поле, содержащее ссылку, выполните эти шаги:

1. Создайте экземпляр класса `Presentation`. 
2. Получите ссылку на первый слайд в только что созданной презентации. 
3. Добавьте объект `AutoShape` с установленным `ShapeType` как `RECTANGLE` в указанной позиции на слайде и получите ссылку на только что добавленный объект AutoShape.
4. Добавьте `text_frame` к объекту `AutoShape`, который содержит *Aspose TextBox* в качестве текста по умолчанию. 
5. Инстанцируйте класс `hyperlink_manager`. 
6. Присвойте объект `hyperlink_manager` свойству [HyperlinkClick](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), связанному с вашим предпочитаемым фрагментом `TextFrame`. 
7. Наконец, запишите файл PPTX через объект `Presentation`. 

Этот код на Python — реализация вышеописанных шагов — показывает, как добавить текстовое поле с гиперссылкой на слайд:

```py
import aspose.slides as slides

# Создает экземпляр класса Presentation, представляющий PPTX
with slides.Presentation() as pptxPresentation:
    # Получает первый слайд в презентации
    slide = pptxPresentation.slides[0]

    # Добавляет объект AutoShape с типом, установленным как Rectangle
    pptxShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    # Получает ITextFrame свойство, связанное с AutoShape
    pptxShape.add_text_frame("")

    textFrame = pptxShape.text_frame

    # Добавляет текст в фрейм
    textFrame.paragraphs[0].portions[0].text = "Aspose.Slides"

    # Устанавливает гиперссылку для текста фрагмента
    hm = textFrame.paragraphs[0].portions[0].portion_format.hyperlink_manager
    hm.set_external_hyperlink_click("http://www.aspose.com")
    # Сохраняет презентацию PPTX
    pptxPresentation.save("hLinkPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```