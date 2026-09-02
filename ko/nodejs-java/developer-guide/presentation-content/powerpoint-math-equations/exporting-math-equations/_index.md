---
title: JavaScript에서 프레젠테이션의 수학 방정식 내보내기
linktitle: 방정식 내보내기
type: docs
weight: 30
url: /ko/nodejs-java/exporting-math-equations/
keywords:
- 수학 방정식 내보내기
- LaTeX로 방정식 내보내기
- PowerPoint를 LaTeX로
- MathML
- LaTeX
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint 프레젠테이션의 수학 방정식을 LaTeX 또는 MathML로 직접 Aspose.Slides for Node.js를 사용하여 Java를 통해 내보냅니다."
---
## **소개**

Aspose.Slides를 사용하면 프레젠테이션에서 수학 방정식을 내보낼 수 있습니다. 예를 들어, 특정 프레젠테이션의 슬라이드에 있는 수학 방정식을 추출하여 다른 프로그램이나 플랫폼에서 사용할 필요가 있을 수 있습니다.

{{% alert color="primary" %}} 
방정식을 LaTeX 또는 MathML(웹 및 많은 애플리케이션에서 사용되는 인기 있는 수학 콘텐츠 표준)으로 직접 내보낼 수 있습니다.
{{% /alert %}}

## **LaTeX으로 수학 방정식 내보내기**

Aspose.Slides는 PowerPoint 수학 방정식을 직접 LaTeX로 변환할 수 있으며, 중간 MathML 파일이나 외부 변환기가 필요하지 않습니다. 수학 방정식은 텍스트 프레임에 [MathPortion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathportion/)으로 저장됩니다. [MathPortion.getMathParagraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathportion/#getMathParagraph--)을 사용하여 [MathParagraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathparagraph/)을 가져오고, 그 다음 [MathParagraph.toLatex](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathparagraph/#toLatex--)를 호출합니다. 이 메서드는 문자열을 반환하며, 이를 저장하거나, 표시하거나, 다른 애플리케이션에 보내거나, 추가로 처리할 수 있습니다.

다음 예제는 모든 슬라이드의 모든 텍스트 프레임을 검사하고, 모든 수학 부분을 찾아 각 방정식을 별개의 `.tex` 파일에 기록합니다:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-)는 슬라이드에서 발견된 모든 텍스트 프레임을 반환합니다. [MathPortion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathportion/) 유형 검사는 일반 텍스트와 이미지와는 구분되는 실제 편집 가능한 방정식을 분리합니다.

모든 LaTeX 엔진 및 문서 템플릿이 동일한 명령, 패키지 또는 유니코드 문자를 지원하는 것은 아닙니다. 반환된 문자열을 애플리케이션에서 사용하는 LaTeX 엔진으로 테스트하십시오. 해당 환경에 적합한 표현이 없는 기호나 Office Math 요소가 있으면, 반환된 문자열에서 프로젝트별 명령으로 교체하거나 방정식을 건너뛰고 문제를 기록하여 검토하십시오.

## **MathML로 수학 방정식 저장**

사람은 LaTeX와 같은 일부 방정식 형식의 코드를 쉽게 작성할 수 있지만, MathML은 애플리케이션에 의해 자동으로 생성되도록 설계되었기 때문에 코드를 작성하기 어렵습니다. 프로그램은 MathML이 XML 형식이므로 쉽게 읽고 구문 분석할 수 있어, 많은 분야에서 MathML이 출력 및 인쇄 형식으로 일반적으로 사용됩니다.

다음 샘플 코드는 프레젠테이션에서 MathML로 수학 방정식을 내보내는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**MathML로 정확히 무엇이 내보내집니까—단락 전체인가요, 개별 수식 블록인가요?**  
전체 수학 단락([MathParagraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathparagraph/))이나 개별 블록([MathBlock](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathblock/)) 중 하나를 MathML로 내보낼 수 있습니다. 두 유형 모두 MathML로 작성하는 메서드를 제공합니다.

**슬라이드의 객체가 일반 텍스트나 이미지가 아니라 수학 수식임을 어떻게 판단할 수 있나요?**  
수식은 [MathPortion](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathportion/)에 존재하고 [MathParagraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathparagraph/)를 가집니다. [MathParagraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathparagraph/)가 없는 이미지와 일반 텍스트 부분은 내보낼 수 있는 수식이 아닙니다.

**프레젠테이션에서 MathML은 어디에서 나오는 건가요—PowerPoint 전용인가요, 표준인가요?**  
내보내기는 표준 MathML(XML)을 목표로 합니다. Aspose는 표준의 프레젠테이션 하위 집합인 Presentation MathML을 사용하며, 이는 다양한 애플리케이션과 웹에서 널리 사용됩니다.

**표, SmartArt, 그룹 등 내부의 수식 내보내기가 지원되나요?**  
예, 해당 객체에 [MathParagraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/mathparagraph/)가 포함된 텍스트 부분(즉, 실제 PowerPoint 수식)이 있으면 내보냅니다. 수식이 이미지로 삽입된 경우는 내보내지 않습니다.

**MathML로 내보낼 때 원본 프레젠테이션이 수정되나요?**  
아니요. MathML을 작성하는 것은 수식 내용의 직렬화일 뿐이며, 프레젠테이션 파일을 수정하지 않습니다.