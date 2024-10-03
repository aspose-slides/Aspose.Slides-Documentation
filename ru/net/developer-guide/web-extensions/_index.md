---
title: Новая система экспорта HTML - Aspose.Slides.WebExtensions
type: docs
weight: 240
url: /ru/net/web-extensions/
keywords: "Экспорт PowerPoint в HTML, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Экспорт PowerPoint в HTML на C# или .NET"
---


## Введение

* В старых сборках API Aspose.Slides, когда вы экспортировали PowerPoint в HTML, полученный HTML представлялся в виде разметки SVG, объединенной с HTML. Каждому слайду соответствовал контейнер SVG.
* В новых версиях Aspose.Slides, когда вы используете систему WebExtensions для экспорта презентаций PowerPoint в HTML, вы можете настроить параметры экспорта HTML для достижения наилучших результатов.

Используя новую систему WebExtensions, вы можете экспортировать всю презентацию в HTML с набором классов CSS и анимациями JavaScript (без SVG). Новая система экспорта также предоставляет неограниченное количество опций и методов, определяющих процесс экспорта.

Новая система WebExtensions используется для генерации HTML из презентаций в следующих случаях и событиях:

* при использовании пользовательских стилей CSS или анимаций; переопределение разметки для определенных типов фигур.
* при переопределении структуры документа, например, используя пользовательскую навигацию между страницами.
* при сохранении файлов .html, .css, .js в папках с пользовательской иерархией, включая специфические типы файлов в разные папки. Например, экспорт слайдов в папку на основе имени раздела.
* при сохранении файлов CSS и JS в отдельные папки по умолчанию и последующем добавлении их в файл HTML. Изображения и встроенные шрифты также сохраняются в отдельные файлы. Однако их можно встроить в файл HTML (в формате base64). Вы можете сохранить некоторые части ресурсов в файлы и встроить другие ресурсы в HTML в формате base64.

Вы можете просмотреть примеры PowerPoint в HTML в проекте [Aspose.Slides.WebExtensions](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/) на GitHub. Этот проект содержит 2 части: **Examples\SinglePageApp** и **Examples\MultiPageApp**. Другие примеры, использованные в этой статье, также можно найти в репозитории GitHub.

### **Шаблоны**

Чтобы еще больше расширить возможности экспорта HTML, мы рекомендуем вам использовать систему шаблонов ASP.NET Razor. Экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) может использоваться вместе с набором шаблонов для получения HTML-документа в качестве результата экспорта.

**Демонстрация**

В этом примере мы экспортируем текст из презентации в HTML. Сначала давайте создадим шаблон:

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
Этот шаблон сохраняется на диске как "shape-template-hello-world.html", который будет использован в следующем шаге.

В этом шаблоне мы перебираем текстовые фреймы в фигурах презентации, чтобы отобразить текст. Давайте сгенерируем HTML-файл, используя WebDocument, а затем экспортируем презентацию в файл:

``` csharp
using (Presentation pres = new Presentation())
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 150);
    shape.TextFrame.Text = "Hello World";
                
    WebDocumentOptions options = new WebDocumentOptions
    {
        TemplateEngine = new RazorTemplateEngine(), // Мы намерены использовать движок шаблонов Razor. Другие движки шаблонов могут использоваться, реализуя ITemplateEngine  
        OutputSaver = new FileOutputSaver() // Другие сохранители результата могут использоваться, реализуя интерфейс IOutputSaver
    };
    WebDocument document = new WebDocument(options);

    // добавляем "вход" документа - какой источник будет использоваться для генерации HTML-документа
    document.Input
        .AddTemplate<Presentation>( // шаблон будет иметь Presentation в качестве "объекта модели" (Model.Object) 
        "index", // ключ шаблона - необходим для сопоставления объекта (Presentation) с шаблоном, загруженным с диска ("shape-template-hello-world.html")  
        @"custom-templates\shape-template-hello-world.html"); // шаблон, который мы создали ранее
                
    // добавляем вывод - как будет выглядеть результирующий HTML-документ, когда он будет экспортирован на диск
    document.Output.Add(
        "hello-world.html", // путь к выходному файлу
        "index", // ключ шаблона, который будет использоваться для этого файла (мы установили его в предыдущем утверждении)  
        pres); // фактический экземпляр Model.Object 
                
    document.Save();
}
```

Например, мы хотим добавить CSS стили к результату экспорта, чтобы изменить цвет текста на красный. Давайте добавим CSS шаблон:

``` css
.text {
    color: red;
}
```

Теперь мы добавляем его во вход и выход:

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

Давайте добавим ссылку на стили в шаблон и класс "text":
``` html
<!DOCTYPE html>
<head>
    <link rel="stylesheet" type="text/css" href="hello-world.css" />
</head>
...
</html>
```

### **Шаблоны по умолчанию**

WebExtensions предоставляют 2 набора основных шаблонов для экспорта презентаций в HTML:
* Одностраничный: весь контент презентации экспортируется в один HTML файл. Все другие ресурсы (изображения, шрифты, стили и т.д.) экспортируются в отдельные файлы.
* Многостраничный: каждый слайд презентации экспортируется в отдельный HTML файл. Логика экспорта ресурсов по умолчанию такая же, как на одной странице.

Класс `PresentationExtensions` может использоваться для упрощения процесса экспорта презентации с использованием шаблонов. Класс `PresentationExtensions` содержит набор методов расширения для класса Presentation. Чтобы экспортировать презентацию на одной странице, просто подключите пространство имен Aspose.Slides.WebExtensions и вызовите два метода. Первый метод, `ToSinglePageWebDocument`, создает экземпляр `WebDocument`. Второй метод сохраняет HTML-документ: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToSinglePageWebDocument("templates\\single-page", @"single-page-output");
    document.Save();
}
```

Метод ToSinglePageWebDocument может принимать два параметра: папку с шаблонами и папку для экспорта.

Чтобы экспортировать презентацию на много страниц, используйте метод ToMultiPageWebDocument с теми же параметрами:

``` csharp
using (Presentation pres = new Presentation("demo.pptx"))
{
    WebDocument document = pres.ToMultiPageWebDocument("templates\\multi-page", @"multi-page-output");
    document.Save();
}
```

В WebExtensions каждый шаблон, используемый для генерации разметки, привязан к ключу. Ключ может использоваться в шаблонах. Например, в директиве @Include вы можете вставить определенный шаблон в другой по ключу.

Мы можем продемонстрировать процедуру на примере использования шаблона порций внутри шаблона абзаца. Вы можете найти пример в проекте Aspose.Slides.WebExtensions: [Templates\common\paragraph.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/paragraph.html). Чтобы нарисовать порции в абзаце, мы перебираем их используя директиву @foreach движка Razor:

``` html
@foreach (Portion portion in contextObject.Portions) 
{ 
    var subModel = Model.SubModel(portion);
    subModel.Local.Put("parentTextFrame", parentTextFrame);
    subModel.Local.Put("tableContent", tableContentFlag);
	@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
}
```

У порции есть свой собственный шаблон [portion.html](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/Templates/common/portion.html) и для него создается модель. Эта модель будет добавлена в выходной шаблон paragraph.html:
``` html
@Raw(Include("portion", subModel).ToString().Replace(Environment.NewLine, ""));
```

Для каждого типа фигуры мы используем пользовательский шаблон, который добавляется в общий набор шаблонов проекта Aspose.Slides.WebExtensions. Шаблоны комбинируются в методах ToSinglePageWebDocument и ToMultiPageWebDocument, чтобы предоставить окончательный результат. Это общие шаблоны, используемые как в одностраничной, так и в многостраничной версии:

-templates
+-common
  ¦ +-scripts: скрипты javascript для анимаций переходов слайдов, например.
  ¦ +-styles: общие CSS стили.
  +-multi-page: приготовление, меню, шаблоны слайдов для многостраничного вывода.
  +-single-page: шаблоны индекса, слайдов для одностраничного экспорта.

Вы можете узнать, как общая часть связана со всеми шаблонами в методе `PresentationExtensions.AddCommonInputOutput` [здесь](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/blob/main/Aspose.Slides.WebExtensions/PresentationExtensions.cs).

### **Настройка шаблонов по умолчанию**

Вы можете изменить любой элемент в шаблоне общей модели. Например, вы можете решить изменить стили форматирования таблицы, но хотите, чтобы все другие стили одностраничного вывода остались неизменными.

По умолчанию используется шаблон Templates\common\table.html, и таблица имеет тот же внешний вид, что и таблица в PowerPoint. Давайте изменим форматирование таблицы, используя пользовательские CSS стили:
``` css
.custom-table {
    border: 1px solid black;
}
.custom-table tr:nth-child(even) {background: #CCC}
.custom-table tr:nth-child(odd) {background: #ffb380}
```

Мы можем создать ту же структуру входных шаблонов и выходных файлов (как это генерируется), вызывая метод `PresentationExtensions.ToSinglePageWebDocument`. Давайте добавим метод `ExportCustomTableStyles_AddCommonStructure` для этого. Разница между этим методом и методом `ToSinglePageWebDocument` заключается в том, что нам не нужно добавлять стандартный шаблон для таблицы и главной индексной страницы (он будет заменен, чтобы включить ссылку на пользовательские стили таблицы):

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

Давайте добавим вместо этого пользовательский шаблон:

``` csharp
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

    // настройка глобальных значений документа
    WebDocument document = new WebDocument(options);
    SetupGlobals(document, options, outputPath);

    // добавляем общую структуру (за исключением шаблона таблицы)
    ExportCustomTableStyles_AddCommonStructure(pres, document, templatesPath, outputPath, options.EmbedImages);
                
    // добавляем пользовательский шаблон таблицы
    document.Input.AddTemplate<Table>("table", @"custom-templates\table-custom-style.html");
                
    // добавляем пользовательские стили таблицы
    document.Input.AddTemplate<Presentation>("table-custom-style", @"custom-templates\styles\table-custom-style.css");
    document.Output.Add(Path.Combine(outputPath, "table-custom-style.css"), "table-custom-style", pres);
                
    // добавляем пользовательский индекс - это просто копия стандартного "index.html", но включает ссылку на "table-custom-style.css"
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

**Примечание**: пользовательский шаблон таблицы был добавлен с тем же ключом "table", что и стандартная таблица. Таким образом, вы можете заменить определенный стандартный шаблон, не переписывая его. Вы также можете использовать шаблоны из стандартной структуры с теми же ключами. Например, вы можете использовать стандартный шаблон абзаца в шаблоне таблицы; вы также можете заменить его по ключу.
Вы также можете использовать index.html, чтобы включить ссылку на пользовательские таблицы CSS стили в него: 

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

## **Создать проект с нуля: Анимация переходов слайдов**

WebExtensions позволяют вам экспортировать презентации с анимацией переходов слайдов — вам просто нужно установить свойство `AnimateTransitions` в `WebDocumentOptions` в значение `true`:

``` csharp
WebDocumentOptions options = new WebDocumentOptions
{
    // ... другие параметры
    AnimateTransitions = true
};
```

Давайте создадим новый проект, который использует Aspose.Slides и Aspose.Slides.WebExtensions для создания HTML-просмотрщика для PDF с плавными анимациями перехода страниц. Здесь нам нужно использовать функцию импорта PDF от Aspose.Slides.

Давайте создадим проект PdfToPresentationToHtml и добавим пакет NuGet Aspose.Slides.WebExtensions (пакет Aspose.Slides также будет добавлен как зависимость):
![NuGet Package](screen.png)

Начнем с импорта PDF-документа, который будет анимирован и экспортирован в HTML-презентацию:

``` csharp
using (Presentation pres = new Presentation())
{
    pres.Slides.RemoveAt(0);
    pres.Slides.AddFromPdf("sample.pdf");
}
```

Теперь мы можем настроить анимацию переходов слайдов (каждый слайд — это импортированная страница PDF). Мы использовали 9 слайдов в образце PDF-документа. Давайте добавим переходы слайдов для каждого из них (демонстрация при просмотре HTML):

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

Наконец, давайте экспортируем его в HTML с помощью `WebDocument`, установив свойство `AnimateTransitions` в значение `true`:

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

Вот и все, что вам нужно для создания HTML с анимацией переходов страниц, созданной из PDF-документа. 

* [Скачать образец HTML файла](https://github.com/aspose-slides/Aspose.Slides.WebExtensions/tree/main/Examples).
* [Скачать образец проекта](/slides/ru/net/web-extensions/sample.zip).