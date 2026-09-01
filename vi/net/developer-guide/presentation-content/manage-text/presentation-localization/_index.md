---
title: Tự động hoá Địa phương hoá Bản trình chiếu trong .NET
linktitle: Địa phương hoá Bản trình chiếu
type: docs
weight: 100
url: /vi/net/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- vô hiệu hoá kiểm tra chính tả
- ngôn ngữ hiệu đính
- id ngôn ngữ
- văn bản đa ngôn ngữ
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Đặt ngôn ngữ hiệu đính cho văn bản bản trình chiếu PowerPoint và OpenDocument trong .NET với Aspose.Slides, bao gồm mặc định và các đoạn văn đa ngôn ngữ."
---
## **Tổng quan**

Aspose.Slides for .NET cho phép bạn cấu hình siêu dữ liệu hiệu đính cho các phần văn bản riêng lẻ. Sử dụng [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/languageid/) để xác định ngôn ngữ hiệu đính, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/spellcheck/) để cho phép hoặc vô hiệu hoá kiểm tra chính tả, và [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/proofdisabled/) để kiểm soát trạng thái không hiệu đính rộng hơn. Vì các cài đặt này được áp dụng ở mức phần, một đoạn văn có thể chứa nhiều ngôn ngữ và các quy tắc hiệu đính khác nhau.

Bài viết này giải thích cách gán ngôn ngữ cho văn bản cụ thể, đặt ngôn ngữ mặc định cho văn bản mới bằng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/defaulttextlanguage/), tạo các đoạn đa ngôn ngữ, chọn giữa `SpellCheck` và `ProofDisabled`, và bảo tồn các cài đặt mong muốn khi sử dụng [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/joinportionswithsameformatting/). Các thuộc tính này lưu trữ siêu dữ liệu cho các ứng dụng trình chiếu; chúng không dịch văn bản, không thực hiện kiểm tra chính tả dựa trên từ điển, và không trả về danh sách các từ sai.

## **Đặt ngôn ngữ hiệu đính cho văn bản**

Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/), truy cập phần văn bản cần thiết qua [IPortion.PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/portionformat/), và gán định danh ngôn ngữ cho nó. Ví dụ sau tạo một hình, đặt tiếng Anh Anh quốc làm ngôn ngữ hiệu đính, và lưu kết quả bằng [Presentation.Save](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Đặt ngôn ngữ mặc định cho văn bản mới**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/defaulttextlanguage/) để chỉ định ngôn ngữ hiệu đính mà Aspose.Slides sẽ gán cho văn bản mới tạo. Cài đặt này hữu ích khi hầu hết hoặc toàn bộ văn bản mới trong một bản trình chiếu sử dụng cùng một ngôn ngữ. Nó không thay đổi siêu dữ liệu ngôn ngữ của văn bản đã có ngôn ngữ xác định.

Ví dụ sau tạo một bản trình chiếu mà văn bản mới sử dụng quy tắc hiệu đính tiếng Đức:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Sử dụng nhiều ngôn ngữ trong một đoạn văn**

Một [IParagraph](https://reference.aspose.com/slides/vi/net/aspose.slides/iparagraph/) chứa một tập hợp các phần văn bản. Tạo một [Portion](https://reference.aspose.com/slides/vi/net/aspose.slides/portion/) riêng cho mỗi ngôn ngữ và đặt `LanguageId` của nó một cách độc lập.

Ví dụ này tạo một đoạn với các phần tiếng Anh và tiếng Pháp:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Bật hoặc vô hiệu hoá kiểm tra chính tả cho các phần riêng lẻ**

[IPortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportionformat/) kế thừa các thuộc tính văn bản chung được định nghĩa bởi [IBasePortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/). Truy cập định dạng của một phần qua [IPortion.PortionFormat](https://reference.aspose.com/slides/vi/net/aspose.slides/iportion/portionformat/) và đặt [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/spellcheck/) để kiểm soát liệu một ứng dụng trình chiếu có cho phép kiểm tra chính tả cho phần đó hay không. Giá trị mặc định là `false`: `true` cho phép kiểm tra chính tả, trong khi `false` vô hiệu hoá nó.

Cài đặt này áp dụng cho các phần văn bản riêng lẻ. Do đó, các phần khác nhau trong cùng một đoạn có thể sử dụng các giá trị khác nhau. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/languageid/) và `SpellCheck` có mục đích bổ trợ nhau: `LanguageId` xác định ngôn ngữ hiệu đính, trong khi `SpellCheck` quyết định liệu có cho phép kiểm tra chính tả cho phần đó hay không.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/vi/net/aspose.slides/baseportionformat/proofdisabled/) cũng kiểm soát hiệu đính, nhưng nó đại diện cho trạng thái "không hiệu đính" rộng hơn dưới dạng [NullableBool](https://reference.aspose.com/slides/vi/net/aspose.slides/nullablebool/). Sử dụng `SpellCheck` khi bạn cần một công tắc Boolean trực tiếp cho việc kiểm tra chính tả. Sử dụng `ProofDisabled` khi bạn cần bảo tồn hoặc kiểm soát một cách rõ ràng siêu dữ liệu không hiệu đính của bản trình chiếu, bao gồm trạng thái `NotDefined`. Nếu bạn đặt cả hai thuộc tính, hãy giữ giá trị của chúng nhất quán; không kết hợp `SpellCheck = true` với `ProofDisabled = NullableBool.True`.

Các thuộc tính này cấu hình siêu dữ liệu hiệu đính được sử dụng bởi PowerPoint và các ứng dụng trình chiếu khác. Aspose.Slides không sử dụng chúng để thực hiện kiểm tra chính tả dựa trên từ điển hoặc trả về danh sách các từ sai.

Ví dụ hoàn chỉnh sau tạo một bản trình chiếu đầu vào, tải nó, gán các cài đặt kiểm tra chính tả và ngôn ngữ hiệu đính khác nhau cho hai phần trong cùng một đoạn, lưu kết quả, mở lại và xác minh các giá trị đã lưu:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/joinportionswithsameformatting/) kết hợp các phần liền kề có cùng định dạng. Chỉ sự khác biệt ở `SpellCheck` không giữ các phần tách biệt; sau khi chúng được ghép, phần kết quả sẽ giữ giá trị `SpellCheck` của phần đầu tiên. Nếu các phần cần các cài đặt kiểm tra chính tả khác nhau, hãy gọi `JoinPortionsWithSameFormatting` trước khi gán các cài đặt đó, hoặc kiểm tra ranh giới của phần kết quả và áp dụng lại các cài đặt sau đó. Các phần có giá trị `LanguageId` khác nhau vẫn tách biệt vì định dạng ngôn ngữ hiệu đính của chúng khác nhau.

## **Câu hỏi thường gặp**

**Mã ngôn ngữ có dịch văn bản không?**

Không. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/languageid/) lưu trữ siêu dữ liệu hiệu đính cho chính tả và ngữ pháp; nó không thay đổi nội dung văn bản. Hãy dịch văn bản riêng biệt, sau đó đặt định danh ngôn ngữ phù hợp cho mỗi phần đã dịch.

**Ngôn ngữ hiệu đính có kiểm soát phông chữ, gạch ngang hay ngắt dòng không?**

Không. Định danh ngôn ngữ chỉ dùng cho việc hiệu đính. Việc hiển thị và bố cục văn bản chủ yếu phụ thuộc vào [phông chữ](/slides/vi/net/powerpoint-fonts/), hệ thống viết và các cài đặt khung văn bản. Để hiển thị đáng tin cậy, cung cấp các phông chữ cần thiết, cấu hình [thay thế phông chữ](/slides/vi/net/font-substitution/), hoặc [nhúng phông chữ](/slides/vi/net/embedded-font/) trong bản trình chiếu.

**Một đoạn có thể sử dụng nhiều ngôn ngữ hiệu đính không?**

Có. Gán mỗi ngôn ngữ cho một phần riêng biệt, như được minh họa trong ví dụ đoạn đa ngôn ngữ.

**Tôi nên sử dụng `DefaultTextLanguage` hay `LanguageId`?**

Sử dụng [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/defaulttextlanguage/) khi bạn muốn đặt ngôn ngữ mặc định cho văn bản mới tạo. Sử dụng [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/vi/net/aspose.slides/ibaseportionformat/languageid/) khi một phần cụ thể cần ngôn ngữ hiệu đính rõ ràng hoặc khi một đoạn chứa nhiều ngôn ngữ.