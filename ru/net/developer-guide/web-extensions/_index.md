---
title: Новая система экспорта HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ru/net/web-extensions/
keywords:
- веб-расширение
- движок шаблонов
- экспорт PowerPoint
- экспорт OpenDocument
- экспорт презентации
- экспорт слайда
- экспорт PPT
- экспорт PPTX
- экспорт ODP
- PowerPoint в HTML
- OpenDocument в HTML
- презентация в HTML
- слайд в HTML
- PPT в HTML
- PPTX в HTML
- ODP в HTML
- .NET
- C#
- Aspose.Slides
description: "Экспортируйте презентации в HTML с шаблонами, CSS и JS — без SVG. Узнайте о выводе в один или несколько файлов, управлении ресурсами и настройке для PPT, PPTX и ODP."
---

## **Введение**

* В старых версиях API Aspose.Slides, при экспорте PowerPoint в HTML, полученный HTML представлялся в виде SVG‑разметки, комбинированной с HTML. Каждый слайд экспортировался как контейнер SVG. 
* В новых версиях Aspose.Slides, при использовании системы WebExtensions для экспорта презентаций PowerPoint в HTML, вы можете настроить параметры экспорта HTML для достижения наилучших результатов. 

Используя новую систему WebExtensions, вы можете экспортировать всю презентацию в HTML с набором CSS‑классов и JavaScript‑анимаций (без SVG). Новая система экспорта также предоставляет неограниченное количество параметров и методов, определяющих процесс экспорта. 

Система WebExtensions используется для генерации HTML из презентаций в следующих случаях и сценариях:

* при использовании пользовательских CSS‑стилей или анимаций; переопределении разметки для определённых типов фигур.  
* при переопределении структуры документа, например, с использованием пользовательской навигации между страницами.
* при сохранении файлов .html, .css, .js в папки с настраиваемой иерархией, включая определённые типы файлов в разные папки. Например, экспорт слайдов в папку, основанную на названии раздела.
* при сохранении CSS и JS файлов в отдельные папки по умолчанию, а затем их добавлении в HTML‑файл. Изображения и встроенные шрифты также сохраняются в отдельные файлы. Однако их можно встроить в HTML‑файл (в формате base64). Вы можете сохранять отдельные части ресурсов в файлы и внедрять другие ресурсы в HTML в виде base64.

Вы можете просмотреть примеры преобразования PowerPoint в HTML в проекте [Aspose.Slides.WebExtensions project](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) на GitHub. Этот проект состоит из 2 частей: **Examples\\SinglePageApp** и **Examples\\MultiPageApp**. Другие примеры, использованные в этой статье, также доступны в репозитории GitHub.

### **Шаблоны**

Чтобы дополнительно расширить возможности экспорта HTML, рекомендуется использовать систему шаблонов ASP.NET Razor. Экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) можно использовать вместе с набором шаблонов для получения HTML‑документа в качестве результата экспорта.

**Демонстрация**

В этом примере мы экспортируем текст из презентации в HTML. Сначала создадим шаблон:
``` html
<!DOCTYPE html>
<body>
    @foreach (Slide slide in Model.Object.Slides)    
    {
        foreach (Shape shape in slide.Shapes)
        {
            if(shape is AutoShape)
            {
                ITextFrame textFrame = ((AutoShape)shape).TextFrame;
                <div class="text">@textFrame.Text</div>
            }
        }
    }
</body>
</html>
```

Этот шаблон сохраняется на диск как "shape-template-hello-world.html", который будет использован на следующем этапе.

В этом шаблоне мы перебираем текстовые фреймы в фигурках презентации, чтобы отобразить текст. Сгенерируем HTML‑файл с помощью WebDocument, а затем экспортируем Presentation в файл: 
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Мы планируем использовать шаблонизатор Razor. Другие шаблонизаторы могут быть использованы путем реализации ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Другие сохраняющие результаты могут быть использованы путем реализации интерфейса IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // добавить документ "input" — какой источник будет использоваться для генерации HTML‑документа
    document.Input
        .AddTemplate<Presentation>( // шаблон будет использовать Presentation как объект "model" (Model.Object) 
        "index", // ключ шаблона — требуется движку шаблонов для сопоставления объекта (Presentation) с шаблоном, загруженным с диска ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // шаблон, созданный ранее
                
    // добавить вывод — как будет выглядеть полученный HTML‑документ после экспорта на диск
    document.Output.Add(
        "hello-world.html", // путь к файлу вывода
        "index", // ключ шаблона, который будет использоваться для этого файла (установлен в предыдущем операторе)  
        pres); // фактический экземпляр Model.Object 
                
    document.Save();
}
```


Например, мы хотим добавить CSS‑стили к результату экспорта, чтобы изменить цвет текста на красный. Добавим CSS‑шаблон:
``` css
.text {
    color: red;
}
```


Теперь добавим его во входные и выходные данные:
``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions { TemplateEngine = new RazorTemplateEngine(), OutputSaver = new FileOutputSaver() };
    WebDocument document = new WebDocument(options);

    document.Input.AddTemplate<Presentation>("index", @"custom-templates\shape-template-hello-world.html");
    document.Input.AddTemplate<Presentation>("styles", @"custom-templates\styles\shape-template-hello-world.css");
    document.Output.Add("hello-world.html", "index", pres); 
    document.Output.Add("hello-world.css", "styles", pres);
                
    document.Save();
}
```


Добавим ссылку на стили в шаблон и класс "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```


### **Шаблоны по умолчанию**

WebExtensions предоставляет 2 набора базовых шаблонов для экспорта презентаций в HTML:
* Одностраничный: всё содержание презентации экспортируется в один HTML‑файл. Все остальные ресурсы (изображения, шрифты, стили и т.д.) экспортируются в отдельные файлы.
* Многостраничный: каждый слайд презентации экспортируется в отдельный HTML‑файл. Логика экспорта ресурсов по умолчанию такая же, как в одностраничном варианте. 

`PresentationExtensions` класс можно использовать для упрощения процесса экспорта презентации с помощью шаблонов. Класс `PresentationExtensions` содержит набор методов‑расширений для класса Presentation. Чтобы экспортировать презентацию в один файл, достаточно подключить пространство имён Aspose.Slides.WebExtensions и вызвать два метода. Первый метод, `ToSinglePageWebDocument`, создаёт экземпляр `WebDocument`. Второй метод сохраняет HTML‑документ: 
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```


Метод ToSinglePageWebDocument может принимать два параметра: папку шаблонов и папку экспорта. 

Чтобы экспортировать презентацию в несколько страниц, используйте метод ToMultiPageWebDocument с теми же параметрами:
``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"mutil-page-output");
    document.Save();
}
```


В WebExtensions каждый шаблон, используемый для генерации разметки, привязан к ключу. Ключ можно использовать в шаблонах. Например, в директиве @Include можно вставить определённый шаблон в другой с помощью ключа.

Мы можем продемонстрировать процедуру на примере использования шаблона части текста внутри шаблона абзаца. Пример можно найти в проекте Aspose.Slides.WebExtensions: [Templates\\common\\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Чтобы отрисовать части в абзаце, мы перебираем их с помощью директивы @foreach Razor Engine:
``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```


Часть имеет собственный шаблон [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html), и для неё генерируется модель. Эта модель будет добавлена в шаблон output paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```


Для каждого типа фигуры мы используем пользовательский шаблон, который добавляется к общему набору шаблонов из проекта Aspose.Slides.WebExtensions. Шаблоны объединяются в методах ToSinglePageWebDocument и ToMultiPageWebDocument для получения конечного результата. Это общие шаблоны, используемые как в одностраничном, так и в многостраничном вариантах:

-templates
+-common
  ¦ +-scripts: javascript‑скрипты для анимаций переходов слайдов, как пример.
  ¦ +-styles: общие CSS‑стили.
  +-multi-page: index, menu, slide шаблоны для многостраничного вывода.
  +-single-page: index, slide шаблоны для одностраничного вывода.

Можно увидеть, как общая часть привязывается ко всем шаблонам, в методе `PresentationExtensions.AddCommonInputOutput` [здесь](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Настройка шаблонов по умолчанию**

Вы можете изменить любой элемент в шаблоне общей модели. Например, вы можете изменить стили оформления таблицы, но захотеть, чтобы остальные стили одностраничного вывода остались без изменений.

По умолчанию используется Templates\\common\\table.html, и таблица выглядит так же, как таблица в PowerPoint. Давайте изменим оформление таблицы, используя пользовательские CSS‑стили:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```


Мы можем создать ту же структуру входных шаблонов и выходных файлов (как она генерируется), вызывая метод `PresentationExtensions.ToSinglePageWebDocument`. Добавим метод `ExportCustomTableStyles_AddCommonStructure` для этого. Разница между этим методом и методом `ToSinglePageWebDocument` — нам не нужно добавлять стандартный шаблон для таблицы и главную страницу индекса (они будут заменены, чтобы включить ссылку на пользовательские стили таблицы):
``` csharp
private static void ExportCustomTableStyles_AddCommonStructure(
    Presentation pres, 
    WebDocument document,
    string templatesPath, 
    string outputPath, 
    bool embedImages)
{
    AddCommonStylesTemplates(document, templatesPath);
            
    document.Input.AddTemplate<Slide>("slide", Path.Combine(templatesPath, "slide.html"));
    document.Input.AddTemplate<AutoShape>("autoshape", Path.Combine(templatesPath, "autoshape.html"));
    document.Input.AddTemplate<TextFrame>("textframe", Path.Combine(templatesPath, "textframe.html"));
    document.Input.AddTemplate<Paragraph>("paragraph", Path.Combine(templatesPath, "paragraph.html"));
    document.Input.AddTemplate<Paragraph>("bullet", Path.Combine(templatesPath, "bullet.html"));
    document.Input.AddTemplate<Portion>("portion", Path.Combine(templatesPath, "portion.html"));
    document.Input.AddTemplate<VideoFrame>("videoframe", Path.Combine(templatesPath, "videoframe.html"));
    document.Input.AddTemplate<PictureFrame>("pictureframe", Path.Combine(templatesPath, "pictureframe.html")); ;
    document.Input.AddTemplate<Shape>("shape", Path.Combine(templatesPath, "shape.html"));

    AddSinglePageCommonOutput(pres, document, outputPath);
            
    AddResourcesOutput(pres, document, embedImages);
            
    AddScriptsOutput(document, templatesPath);
}
```


Добавим вместо этого пользовательский шаблон:
```csharp
using (Presentation pres = new Presentation("table.pptx"))
{
    const string templatesPath = "templates\\single-page";
    const string outputPath = "custom-table-styles";
                
    var options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        EmbedImages = false
    };

    // настроить глобальные значения документа
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // добавить общую структуру (кроме шаблона таблицы)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // добавить пользовательский шаблон таблицы
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // добавить пользовательские стили таблицы
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // добавить пользовательский индекс — это просто копия стандартного "index.html", но включает ссылку на "table-custom-style.css"
    document.Input.AddTemplate<Presentation>("index", @"custom-templates\index-table-custom-style.html");
                
    document.Save();
}
```

``` html
@model TemplateContext<Table>

@{
    Table contextObject = Model.Object;
    
    var origin = Model.Local.Get<Point>("origin");
    var positionStyle = string.Format("left: {0}px; top: {1}px; width: {2}px; height: {3}px;",
                                        (int)contextObject.X + origin.X,
                                        (int)contextObject.Y + origin.Y,
                                        (int)contextObject.Width,
                                        (int)contextObject.Height);
}

    <table class="table custom-table" style="@positionStyle">
    @for (int i = 0; i < contextObject.Rows.Count; i++)
    {
        var rowHeight = string.Format("height: {0}px", contextObject.Rows[i].Height);
        <tr style="@rowHeight">
        @for (int j = 0; j < contextObject.Columns.Count; j++)
        {
            var cell = contextObject[j, i];
            if (cell.FirstRowIndex ==  i && cell.FirstColumnIndex == j)
            {
                var spans = cell.IsMergedCell ? string.Format("rowspan=\"{0}\" colspan=\"{1}\"", cell.RowSpan, cell.ColSpan) : "";
                <td width="@cell.Width px" @Raw(spans)>
                    @{
                        for(int k = 0; k < cell.TextFrame.Paragraphs.Count; k++)
                        {
                            var para = (Paragraph)cell.TextFrame.Paragraphs[k];
                        
                            var subModel = Model.SubModel(para);
                            double[] margins = new double[] { cell.MarginLeft, cell.MarginTop, cell.MarginRight, cell.MarginBottom };
                            subModel.Local.Put("margins", margins);
                            subModel.Local.Put("parent", cell.TextFrame);
                            subModel.Local.Put("parentContainerSize", new SizeF((float)cell.Width, (float)cell.Height));
                            subModel.Local.Put("tableContent", true);
                            
                            @Include("paragraph", subModel)
                        }
                    }
                </td>
            }
        }
        </tr>
    }
</table>
```


**Примечание** что пользовательский шаблон таблицы был добавлен с тем же ключом “table”, что и стандартный шаблон. Таким образом, вы можете заменить определённый шаблон по умолчанию без его переписывания. Вы также можете использовать шаблоны из стандартной структуры с теми же ключами. Например, можно использовать стандартный шаблон абзаца в шаблоне таблицы; можно также заменить его с помощью ключа.
Вы также можете использовать index.html, чтобы включить ссылку на пользовательские CSS‑стили таблицы в него: 
``` html
<!DOCTYPE html>    
    
<html     
    xmlns="http://www.w3.org/1999/xhtml"    
    xmlns:svg="http://www.w3.org/2000/svg"    
    xmlns:xlink="http://www.w3.org/1999/xlink">    
<head>    
     ...
    <link rel="stylesheet" type="text/css" href="table-custom-style.css" />
    ...
</head>    
<body>    
    ...
</body>
</html>
```


## **Создание проекта с нуля: анимированные переходы между слайдами**

WebExtensions позволяет экспортировать презентации с анимированными переходами между слайдами — достаточно установить свойство `AnimateTransitions` в `WebDocumentOptions` в значение `true`:
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... другие параметры
    AnimateTransitions = true
};
```


Создадим новый проект, который использует Aspose.Slides и Aspose.Slides.WebExtensions для создания HTML‑просмотрщика PDF с плавными анимированными переходами страниц. Здесь нам потребуется использовать функцию импорта PDF из Aspose.Slides.

Создадим проект PdfToPresentationToHtml и добавим пакет NuGet Aspose.Slides.WebExtensions (пакет Aspose.Slides также будет добавлен как зависимость):
![NuGet Package](screen.png)

Начнём с импортирования PDF‑документа, который будет анимирован и экспортирован в HTML‑презентацию:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```


Теперь можем настроить анимированные переходы слайдов (каждый слайд — импортированная страница PDF). В образце PDF‑документа используется 9 слайдов. Добавим переходы между слайдами в каждый из них (демонстрация при просмотре HTML):
``` csharp
pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;
```


Наконец, экспортируем его в HTML с помощью `WebDocument`, установив свойство `AnimateTransitions` в `true`:
``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    TemplateEngine = new RazorTemplateEngine(),
    OutputSaver = new FileOutputSaver(),
    AnimateTransitions = true
};

WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
document.Save();
```


Полный пример исходного кода:
``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Fade;
    pres.Slides[1].SlideShowTransition.Type = TransitionType.RandomBar;
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Cover;
    pres.Slides[3].SlideShowTransition.Type = TransitionType.Dissolve;
    pres.Slides[4].SlideShowTransition.Type = TransitionType.Switch;
    pres.Slides[5].SlideShowTransition.Type = TransitionType.Pan;
    pres.Slides[6].SlideShowTransition.Type = TransitionType.Ferris;
    pres.Slides[7].SlideShowTransition.Type = TransitionType.Pull;
    pres.Slides[8].SlideShowTransition.Type = TransitionType.Plus;

    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(),
        OutputSaver = new FileOutputSaver(),
        AnimateTransitions = true
    };

    WebDocument document = pres.ToSinglePageWebDocument(options, "templates\\single-page", "animated-pdf");
    document.Save();
}
```


Это всё, что необходимо для создания HTML с анимированными переходами страниц, сгенерированными из PDF‑документа. 

* [Скачать пример HTML‑файла](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Скачать пример проекта](/slides/ru/net/web-extensions/sample.zip).