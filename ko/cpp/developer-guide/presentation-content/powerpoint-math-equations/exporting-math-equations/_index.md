---
title: 프레젠테이션에서 C++로 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/cpp/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- LaTeX로 방정식 내보내기
- PowerPoint에서 LaTeX로
- MathML
- LaTeX
- 파워포인트
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션의 수학 방정식을 LaTeX 또는 MathML로 직접 내보냅니다."
---
## **소개**

Aspose.Slides for C++는 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 수 있습니다.

{{% alert color="info" %}} 

수식은 LaTeX 또는 MathML로 직접 내보낼 수 있습니다. MathML은 웹 및 다양한 애플리케이션에서 사용되는 수학 콘텐츠의 인기 있는 표준입니다.

{{% /alert %}}

## **LaTeX로 수학 방정식 내보내기**

Aspose.Slides는 PowerPoint 수학 방정식을 직접 LaTeX로 변환할 수 있습니다; 중간 MathML 파일이나 외부 변환기가 필요하지 않습니다. 수학 방정식은 텍스트 프레임에 [IMathPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/imathportion/)으로 저장됩니다. [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/)을 사용하여 [IMathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/imathparagraph/)을 얻고, 그 다음 [IMathParagraph::ToLatex](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/imathparagraph/tolatex/)를 호출합니다. 이 메서드는 문자열을 반환하며, 이를 저장, 표시, 다른 애플리케이션에 전송하거나 추가로 처리할 수 있습니다.

다음 예제는 모든 슬라이드의 모든 텍스트 프레임을 검사하고, 모든 수학 부분을 찾아 각 방정식을 별도의 `.tex` 파일에 기록합니다:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/ko/cpp/aspose.slides.util/slideutil/getalltextboxes/)는 슬라이드에서 찾은 모든 텍스트 프레임을 반환합니다. [IMathPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/imathportion/) 타입 검사는 일반 텍스트 및 이미지와 구분되는 실제 편집 가능한 방정식을 구분합니다.

LaTeX 엔진 및 문서 템플릿은 모두 동일한 명령, 패키지 또는 유니코드 문자를 지원하지 않습니다. 반환된 문자열을 애플리케이션에서 사용하는 LaTeX 엔진으로 테스트하십시오. 해당 환경에서 기호나 Office Math 요소에 적합한 표현이 없으면, 반환된 문자열에서 프로젝트 전용 명령으로 교체하거나 방정식을 건너뛰고 문제를 기록하여 검토하십시오.

## **MathML로 수학 방정식 저장**

LaTeX와 같은 일부 방정식 형식은 사람이 쉽게 코드를 작성할 수 있지만, MathML은 애플리케이션에 의해 자동으로 생성되도록 설계되었기 때문에 코드를 작성하기 어렵습니다. MathML은 코드를 XML 형태로 제공하므로 프로그램이 쉽게 읽고 구문 분석할 수 있으며, 따라서 많은 분야에서 출력 및 인쇄 형식으로 널리 사용됩니다.

다음 샘플 코드는 프레젠테이션에서 MathML로 수학 방정식을 내보내는 방법을 보여줍니다:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **FAQ**

**MathML에 정확히 무엇이 내보내지나요—문단 전체인가요, 개별 수식 블록인가요?**

전체 수학 문단([MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/))이든 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathblock/))이든 MathML로 내보낼 수 있습니다. 두 유형 모두 MathML로 작성하는 메서드를 제공합니다.

**슬라이드의 객체가 일반 텍스트나 이미지가 아니라 수학 수식임을 어떻게 알 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/)를 가집니다. [MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/)가 없는 이미지와 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션의 MathML은 어디에서 온 것인가요—PowerPoint 전용인가요, 표준인가요?**

내보내기는 표준 MathML(XML)을 대상으로 합니다. Aspose는 프레젠테이션 MathML—표준의 프레젠테이션 하위 집합—을 사용하며, 이는 애플리케이션 및 웹 전반에 널리 사용됩니다.

**표, SmartArt, 그룹 등 안에 있는 수식을 내보내는 것이 지원되나요?**

예, 해당 객체에 [MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/)가 포함된 텍스트 부분이 있으면(즉, 실제 PowerPoint 수식) 내보내집니다. 수식이 이미지로 삽입된 경우에는 내보내지 않습니다.

**MathML로 내보내면 원본 프레젠테이션이 수정되나요?**

아니요. MathML을 작성하는 것은 수식 내용의 직렬화이며 프레젠테이션 파일을 수정하지 않습니다.