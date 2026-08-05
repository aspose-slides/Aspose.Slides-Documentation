---
title: C++에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/cpp/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint의 수학 방정식을 MathML로 원활하게 내보내고, 서식을 보존하며 호환성을 높입니다."
---
## **소개**

Aspose.Slides for C++는 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 수 있습니다. 

{{% alert color="primary" %}} 

방정식을 MathML로 내보낼 수 있습니다. MathML은 웹 및 다양한 애플리케이션에서 볼 수 있는 수학 방정식 및 유사한 콘텐츠를 위한 널리 사용되는 형식 또는 표준입니다. 

{{% /alert %}}

## **수학 방정식을 MathML로 저장**

LaTeX와 같은 일부 방정식 형식은 사람이 쉽게 코드를 작성할 수 있지만, MathML은 애플리케이션에 의해 자동으로 생성되도록 설계되었기 때문에 코드를 직접 작성하기는 어렵습니다. MathML은 XML 형식이므로 프로그램이 쉽게 읽고 구문 분석할 수 있어 많은 분야에서 출력 및 인쇄 형식으로 일반적으로 사용됩니다. 

다음 샘플 코드는 프레젠테이션에서 수학 방정식을 MathML로 내보내는 방법을 보여줍니다:

``` cpp
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

**MathML로 정확히 무엇이 내보내집니까—문단 전체인가 개별 수식 블록인가?**

MathML로 전체 수학 문단([MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/)) 또는 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathblock/))을 내보낼 수 있습니다. 두 유형 모두 MathML로 기록하는 메서드를 제공합니다.

**슬라이드의 객체가 일반 텍스트나 이미지가 아니라 수학 수식인지 어떻게 알 수 있나요?**

수식은 [MathPortion](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathportion/)에 존재하며 [MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/)를 가지고 있습니다. [MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/)가 없는 이미지와 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션에서 MathML은 어디에서 오는 것인가—PowerPoint 전용인가, 표준인가?**

내보내기는 표준 MathML(XML)을 목표로 합니다. Aspose는 표준의 프레젠테이션 하위 집합인 Presentation MathML을 사용하며, 이는 애플리케이션 및 웹 전반에서 널리 사용됩니다.

**표, SmartArt, 그룹 등 내부의 수식 내보내기가 지원되나요?**

예, 해당 객체에 [MathParagraph](https://reference.aspose.com/slides/ko/cpp/aspose.slides.mathtext/mathparagraph/)가 포함된 텍스트 부분(즉, 실제 PowerPoint 수식)이 있으면 내보내집니다. 수식이 이미지로 삽입된 경우에는 내보내지 않습니다.

**MathML로 내보내면 원본 프레젠테이션이 수정되나요?**

아니요. MathML을 작성하는 것은 수식 내용을 직렬화하는 것이며, 프레젠테이션 파일을 수정하지 않습니다.