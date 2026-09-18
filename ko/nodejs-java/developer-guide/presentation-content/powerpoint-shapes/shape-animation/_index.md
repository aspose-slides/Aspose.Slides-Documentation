---
title: JavaScript를 사용하여 프레젠테이션에 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/nodejs-java/shape-animation/
keywords:
- 도형
- 애니메이션
- 효과
- 애니메이션 도형
- 애니메이션 텍스트
- 애니메이션 추가
- 애니메이션 가져오기
- 애니메이션 추출
- 효과 추가
- 효과 가져오기
- 효과 추출
- 효과 사운드
- 애니메이션 적용
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 도형 애니메이션, 타이밍, 사운드, 애니메이션 후 동작 및 애니메이션 텍스트를 추가, 검사 및 사용자 지정하는 방법을 배우세요."
---
## **개요**

효과 내부의 개별 동작을 다루거나 모션 경로 세그먼트를 편집하려면 [Custom Animation](/slides/ko/nodejs-java/custom-animation/)를 참조하십시오.

Aspose.Slides for Node.js via Java는 슬라이드 애니메이션을 슬라이드 타임라인의 효과로 나타냅니다. 효과에는 대상 도형, 애니메이션 유형 및 하위 유형, 트리거, 타이밍 설정, 그리고 옵션으로 사운드나 후속 애니메이션 동작과 같은 속성이 포함됩니다.

타임라인에는 두 종류의 시퀀스가 있습니다:

- **주 시퀀스**는 슬라이드가 진행될 때 재생됩니다.
- **대화형 시퀀스**는 트리거 도형을 클릭하면 시작됩니다.

텍스트 상자, 그림, 차트, 표 및 기타 슬라이드 개체는 모두 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 객체이므로 대부분의 슬라이드 콘텐츠에 대해 동일한 [Sequence.addEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#addEffect) 메서드를 사용합니다. 사용 가능한 효과는 [EffectType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effecttype/) 열거형에 나열되어 있습니다.

## **도형 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 주 시퀀스를 가져와서 대상 도형, 효과 유형, 하위 유형 및 트리거와 함께 [Sequence.addEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#addEffect) 를 호출합니다. 다른 도형을 클릭하면 시작되는 효과의 경우, 해당 다른 도형을 트리거로 하는 대화형 시퀀스를 생성합니다.

다음 예제는 두 종류의 애니메이션을 모두 생성하고 결과를 `shape-animations.pptx`에 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

트리거는 효과가 시작되는 시점을 제어합니다:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effecttriggertype/#OnClick) 은 주 시퀀스에서는 클릭을 기다리며, 대화형 시퀀스에서는 트리거 도형의 클릭을 기다립니다.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) 은 이전 효과와 동시에 시작됩니다.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) 은 이전 효과가 끝난 후 시작됩니다.

그림, 차트 또는 다른 도형 유형을 애니메이트하려면 `targetShape` 대신 해당 객체를 [Sequence.addEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#addEffect) 에 전달하십시오. 차트 전용 그룹화 옵션은 [Animated Charts](/slides/ko/nodejs-java/animated-charts/)를 참조하세요.

## **도형 애니메이션 읽기**

대상 도형을 알고 있을 때는 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#getEffectsByShape) 를 사용합니다. 모든 효과를 검사하려면 주 시퀀스와 모든 대화형 시퀀스를 열거합니다. 열거는 시퀀스에 인덱스 `0` 에 효과가 있다고 가정하는 것을 방지합니다.

다음 예제는 주 시퀀스 및 대화형 효과가 있는 도형을 만든 다음, 해당 도형을 대상으로 하는 효과를 가져오고, 슬라이드의 모든 시퀀스를 열거합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

하나의 도형에 대한 효과만 필요할 경우, 이름, 자리표시자 유형 또는 다른 안정적인 속성으로 도형을 먼저 식별한 다음 [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#getEffectsByShape) 를 호출하십시오. 인덱스 `0` 에 있는 [ShapeCollection.get_Item](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#get_Item) 이 항상 의도한 객체라고 가정하지 마세요.

## **상속된 자리표시자 효과 작업**

일반 슬라이드의 자리표시자는 레이아웃 슬라이드 및 마스터 슬라이드에 있는 해당 자리표시자로부터 애니메이션 동작을 상속할 수 있습니다. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 은 상위 자리표시자를 반환하며, 상위가 없을 경우 `null` 을 반환합니다.

다음 예제 프레젠테이션에서, 푸터는 일반 슬라이드에서는 **Random Bars**, 레이아웃 슬라이드에서는 **Split**, 마스터 슬라이드에서는 **Fly In** 효과를 가지고 있습니다.

![일반 슬라이드의 푸터 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 푸터 자리표시자 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 푸터 자리표시자 애니메이션 효과](master-shape-animation.png)

다음 예제는 새 프레젠테이션에서 자리표시자 계층을 사용합니다. 마스터 자리표시자, 레이아웃 자리표시자 및 일반 슬라이드의 해당 자리표시자에 효과를 추가합니다. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getBasePlaceholder) 호출 결과가 `null` 이 아닌지 확인한 후 반환된 도형을 사용합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **애니메이션 타이밍 변경**

PowerPoint **Timing** 대화 상자는 [Timing](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/) 속성에 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화 상자](shape-animation.png)

- **Start** 는 [Timing.getTriggerType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#getTriggerType) 에 매핑됩니다.
- **Duration** 은 초 단위의 [Timing.getDuration](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#getDuration) 에 매핑됩니다.
- **Delay** 은 초 단위의 [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) 에 매핑됩니다.
- **Repeat** 은 [Timing.getRepeatCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) 또는 [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) 에 매핑됩니다.
- **Rewind when done playing** 은 [Timing.getRewind](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#getRewind) 에 매핑됩니다.

이 독립 예제는 효과를 추가하고, [Sequence.addEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#addEffect) 로 반환된 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [Effect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/) 참조를 유지하면 불필요한 컬렉션 인덱스를 피할 수 있습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

반복 모드를 하나만 사용하십시오. 반복 횟수와 “until” 플래그를 동시에 지정하면 다양한 뷰어에서 혼란스러운 결과가 나타날 수 있습니다. 반복 모드를 변경할 때는 [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) 및 [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) 를 먼저 설정한 뒤 [Timing.setRepeatCount](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/timing/#setRepeatCount) 를 호출하세요. 어느 플래그를 설정하든 활성 반복 모드가 바뀝니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [Effect.getSound](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#getSound) 로 삽입된 오디오를 참조할 수 있습니다. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#setStopPreviousSound) 은 이전 효과에서 시작된 오디오를 중지하도록 지정합니다.

### **효과에 사운드 추가**

다음 예제는 `animation-sound.wav` 라는 로컬 오디오 파일을 요구합니다. 두 개의 효과를 만들고, 첫 번째 효과에 해당 파일을 사운드로 삽입하며, 두 번째 효과를 사운드를 중지하도록 구성합니다. [Sequence.addEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#addEffect) 로 반환된 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **삽입된 효과 사운드 추출**

다음 예제는 `presentation-with-animation-sounds.pptx` 라는 로컬 프레젠테이션을 요구합니다. 주 및 대화형 시퀀스를 모두 스캔하고, 모든 삽입된 효과 사운드를 `extracted-animation-sounds` 디렉터리에 저장합니다. 확장자는 [Audio.getContentType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/audio/#getContentType) 로 노출된 오디오 MIME 유형에서 선택됩니다.

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

대용량 오디오 객체의 경우, 전체 객체를 바이트 배열로 로드하는 대신 [Audio.getStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/audio/#getStream) 를 사용해 스트림을 파일에 복사하십시오.

## **후속 애니메이션 동작 설정**

**After animation** 옵션은 효과가 끝난 후 도형에 어떤 일이 일어나는지를 제어합니다.

![After animation 설정을 보여주는 PowerPoint 효과 옵션 대화 상자](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/) 열거형은 도형을 그대로 두기, 색상 변경, 애니메이션 후 숨기기, 또는 다음 클릭 시 숨기기 등을 지원합니다. 타입이 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/#Color) 인 경우, [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) 도 설정해야 합니다.

이 독립 예제는 효과를 만들고, 반환된 효과 객체를 통해 후속 애니메이션 동작을 설정한 뒤 결과를 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/afteranimationtype/#Color) 외의 타입으로 변경하면 후속 애니메이션 색상 설정이 삭제됩니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 가지 관련 제어가 있습니다:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textanimation/#getBuildType) 은 문단이 함께 나타나는지 문단 수준별로 나타나는지를 제어합니다.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#getAnimateTextType) 은 텍스트가 한 번에, 단어별, 혹은 글자별로 나타나는지를 제어합니다. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) 은 단어 또는 글자 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율이며, 음수 값은 초 단위 지연입니다.

다음 독립 예제는 텍스트 상자 안의 단어들을 애니메이트합니다. [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/buildtype/#AsOneObject) 은 문단별 빌드를 비활성화하여 단어 설정이 전체 텍스트 프레임에 적용되도록 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

문단별로 텍스트 상자를 빌드하려면 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (또는 다른 문단 수준) 를 사용하십시오. 단일 문단에 자체 효과를 지정하려면 [Paragraph](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/paragraph/) 를 받는 [Sequence.addEffect](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sequence/#addEffect) 오버로드를 사용합니다. 문단 수준 예제는 [Animated Text](/slides/ko/nodejs-java/animated-text/) 를 참고하세요.

## **내보내기 및 호환성 참고 사항**

- PPT 또는 PPTX 로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어에 의해 제어됩니다.
- PDF 및 정적 이미지에서는 애니메이션이 재생되지 않습니다. 움직임을 보여야 할 경우 [HTML5 export](/slides/ko/nodejs-java/export-to-html5/), 애니메이션 GIF 또는 [video conversion](/slides/ko/nodejs-java/convert-powerpoint-to-video/) 를 사용하십시오.
- HTML5 용으로는 [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/#setAnimateShapes) 를 활성화하고, 필요에 따라 [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) 도 설정하십시오.
- 비디오 렌더링은 많은 일반적인 입장, 강조, 퇴장 및 모션 경로 효과를 지원하지만 모든 PowerPoint 효과를 지원하지는 않습니다. 현재 [supported animations and effects](/slides/ko/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) 를 확인하고 대상 Aspose.Slides 버전으로 중요한 프레젠테이션을 테스트하십시오.
- 고급 사용자 정의 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있으나 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름에만 의존하지 말고 내보낸 결과를 검증하십시오.

## **FAQ**

**왜 PowerPoint에서는 애니메이션이 보이는데 PDF에서는 보이지 않나요?**

PDF는 정적 포맷이므로 애니메이션과 슬라이드 전환이 재생되지 않습니다. 움직임을 유지해야 할 경우 HTML5, 애니메이션 GIF 또는 비디오로 내보내십시오.

**왜 비디오에서 효과가 다르게 재생되나요?**

비디오 내보내기는 애니메이션을 실제로 렌더링하며 원본 PowerPoint 동작을 저장하지 않습니다. 일부 고급 효과는 지원되지 않거나 근사화됩니다. 지원되는 효과 표를 검토하고 실제 프레젠테이션을 테스트한 후 사용하십시오.

**도형을 앞으로 또는 뒤로 이동하면 애니메이션 순서가 바뀝니까?**

아니요. 도형의 z‑order는 겹침을 제어하고, 시퀀스 순서와 트리거가 애니메이션 재생을 제어합니다. 재생 순서를 바꾸려면 타임라인을 조정하십시오.