---
title: ".NET에서 프레젠테이션 현지화 자동화"
linktitle: "프레젠테이션 현지화"
type: docs
weight: 100
url: /ko/net/presentation-localization/
keywords:
- "언어 변경"
- "맞춤법 검사"
- "맞춤법 검사 억제"
- "교정 언어"
- "언어 ID"
- "다국어 텍스트"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션 텍스트의 교정 언어를 설정하고, 기본값 및 다국어 단락을 포함합니다."
---
## **개요**

Aspose.Slides for .NET은 개별 텍스트 부분에 대한 교정 메타데이터를 구성할 수 있도록 합니다. 교정 언어를 지정하려면 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/languageid/)를 사용하고, 철자 검사를 허용하거나 억제하려면 [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/spellcheck/)를, 보다 광범위한 교정 비활성 상태를 제어하려면 [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/proofdisabled/)를 사용합니다. 이러한 설정은 부분 수준에서 적용되므로 하나의 단락에 여러 언어와 다른 교정 규칙을 포함시킬 수 있습니다.

이 문서에서는 특정 텍스트에 언어를 할당하고, 새 텍스트에 대한 기본 언어를 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/defaulttextlanguage/)으로 설정하며, 다국어 단락을 구성하고, `SpellCheck`와 `ProofDisabled` 중 하나를 선택하고, [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/joinportionswithsameformatting/)을 사용할 때 의도한 설정을 보존하는 방법을 설명합니다. 이러한 속성은 프레젠테이션 응용 프로그램용 메타데이터를 저장할 뿐이며, 텍스트를 번역하거나 사전 기반 철자 검사를 수행하거나 맞춤법 오류를 반환하지 않습니다.

## **텍스트에 대한 교정 언어 설정**

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/)을 생성하거나 로드하고, [IPortion.PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/portionformat/)을 통해 필요한 텍스트 부분에 접근한 다음 해당 언어 식별자를 지정합니다. 다음 예제는 도형을 만들고, 영국 영어를 교정 언어로 설정한 후, 결과를 [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/)으로 저장합니다.

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

## **새 텍스트에 대한 기본 언어 설정**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/defaulttextlanguage/)을 사용하여 Aspose.Slides가 새로 생성된 텍스트에 자동으로 할당하는 교정 언어를 지정합니다. 이 설정은 프레젠테이션의 대부분 또는 전체 새 텍스트가 동일한 언어를 사용할 때 유용합니다. 이미 명시적인 언어가 지정된 텍스트의 메타데이터는 변경되지 않습니다.

다음 예제는 새 텍스트에 독일어 교정 규칙을 적용하는 프레젠테이션을 만듭니다.

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

## **한 단락에서 여러 언어 사용**

[IParagraph](https://reference.aspose.com/slides/ko/net/aspose.slides/iparagraph/)는 텍스트 부분 컬렉션을 포함합니다. 각 언어마다 별도의 [Portion](https://reference.aspose.com/slides/ko/net/aspose.slides/portion/)를 생성하고 `LanguageId`를 독립적으로 설정합니다.

다음 예제는 영어와 프랑스어 부분을 포함하는 한 단락을 생성합니다.

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

## **개별 부분에 대한 철자 검사 활성화 또는 억제**

[IPortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportionformat/)은 [IBasePortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/)에서 정의된 공통 텍스트 속성을 상속합니다. [IPortion.PortionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/iportion/portionformat/)을 통해 부분의 형식에 접근하고, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/spellcheck/)을 설정하여 프레젠테이션 응용 프로그램이 해당 부분의 철자를 검사할지 여부를 제어합니다. 기본값은 `false`이며, `true`는 검사 허용, `false`는 억제를 의미합니다.

이 설정은 개별 텍스트 부분에 적용됩니다. 같은 단락의 다른 부분은 서로 다른 값을 가질 수 있습니다. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/languageid/)와 `SpellCheck`는 보완적인 역할을 합니다. `LanguageId`는 교정 언어를 식별하고, `SpellCheck`는 해당 부분에 대한 철자 검사 허용 여부를 결정합니다.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/proofdisabled/)도 교정을 제어하지만, 이는 [NullableBool](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/) 형태의 보다 넓은 “교정 안 함” 상태를 나타냅니다. 철자 검사를 직접 제어하려면 `SpellCheck`를 사용하고, 프레젠테이션의 교정 메타데이터(특히 `NotDefined` 상태)를 보존하거나 명시적으로 제어해야 할 경우 `ProofDisabled`를 사용하십시오. 두 속성을 모두 설정하는 경우 값이 일치하도록 유지하고, `SpellCheck = true`와 `ProofDisabled = NullableBool.True`를 동시에 사용하지 마십시오.

이 속성들은 PowerPoint 및 기타 프레젠테이션 응용 프로그램에서 사용하는 교정 메타데이터를 구성합니다. Aspose.Slides는 이를 사용해 사전 기반 철자 검사를 수행하거나 맞춤법 오류 목록을 반환하지 않습니다.

다음 전체 예제는 입력 프레젠테이션을 만들고, 로드한 뒤 같은 단락의 두 부분에 서로 다른 철자 검사 설정과 교정 언어를 할당하고, 결과를 저장한 후 다시 열어 저장된 값을 검증합니다.

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

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/joinportionswithsameformatting/)은 동일한 형식을 가진 인접 부분을 결합합니다. `SpellCheck` 값만 다르면 이러한 부분이 자동으로 분리되지 않으며, 결합된 후 결과 부분은 첫 번째 부분의 `SpellCheck` 값을 유지합니다. 부분마다 다른 철자 검사 설정이 필요하면 해당 설정을 할당하기 전에 `JoinPortionsWithSameFormatting`을 호출하거나, 결합 후 결과 부분 경계를 확인하고 설정을 다시 적용하십시오. `LanguageId` 값이 다른 부분은 교정 언어 형식이 다르기 때문에 별도로 유지됩니다.

## **FAQ**

**언어 ID가 텍스트를 번역합니까?**

아니요. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/languageid/)는 철자 및 문법 교정을 위한 메타데이터를 저장할 뿐이며, 텍스트 내용 자체를 변경하지 않습니다. 텍스트는 별도로 번역한 뒤, 각 번역된 부분에 적절한 언어 식별자를 설정하십시오.

**교정 언어가 글꼴, 하이픈 삽입 또는 줄 바꿈을 제어합니까?**

아니요. 언어 식별자는 교정을 위한 것이며, 텍스트 렌더링 및 레이아웃은 사용 가능한 [fonts](/slides/ko/net/powerpoint-fonts/), 쓰기 시스템 및 텍스트 프레임 설정에 주로 의존합니다. 안정적인 표시를 위해 필요한 글꼴을 제공하고, [font substitution](/slides/ko/net/font-substitution/)을 구성하거나 프레젠테이션에 [embed fonts](/slides/ko/net/embedded-font/)를 포함하십시오.

**한 단락에 여러 교정 언어를 사용할 수 있습니까?**

네. 다국어 단락 예제와 같이 각 언어를 별도의 부분에 할당하면 됩니다.

**`DefaultTextLanguage`와 `LanguageId` 중 어느 것을 사용해야 합니까?**

새로 만든 텍스트에 대한 기본값이 필요하면 [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/defaulttextlanguage/)를 사용하십시오. 특정 부분에 명시적인 교정 언어가 필요하거나 단락에 다국어가 포함된 경우 [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/ko/net/aspose.slides/ibaseportionformat/languageid/)를 사용하십시오.