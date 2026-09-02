---
title: Android でのプレゼンテーションにおけるシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/androidjava/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーションの追加
- アニメーションの取得
- アニメーションの抽出
- エフェクトの追加
- エフェクトの取得
- エフェクトの抽出
- エフェクト サウンド
- アニメーションの適用
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、シェイプ アニメーション、タイミング、サウンド、アフター アニメーション 動作、アニメーション テキストの追加、検査、カスタマイズ方法を学びます。"
---
## **概要**

Aspose.Slides for Android via Java は、スライド アニメーションをスライド タイムライン上のエフェクトとして表現します。エフェクトは対象シェイプ、アニメーションの種類とサブタイプ、トリガー、タイミング設定、そしてオプションでサウンドやアフター アニメーション 動作といったプロパティを持ちます。

タイムラインには次の 2 種類のシーケンスがあります。

- **メイン シーケンス** はスライドが進むと同時に再生されます。  
- **インタラクティブ シーケンス** はトリガー シェイプがクリックされたときに開始します。

テキスト ボックス、画像、チャート、テーブル、その他のスライド オブジェクトはすべて [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) を実装しているため、ほとんどのスライド コンテンツに対して同じ[ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttype/) クラスに列挙されています。

## **図形アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、対象シェイプ、エフェクト タイプ、サブタイプ、トリガーを指定して [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) を呼び出します。他のシェイプがクリックされたときに開始するエフェクトを作成する場合は、そのシェイプをトリガーとするインタラクティブ シーケンスを作成します。

次の例は両方のタイプのアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

トリガーはエフェクトの開始タイミングを制御します。

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttriggertype/#OnClick) はメイン シーケンスではクリック待ち、インタラクティブ シーケンスではトリガー シェイプのクリック待ちです。  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) は直前のエフェクトと同時に開始します。  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) は直前のエフェクトが終了したときに開始します。

画像、チャート、その他のシェイプをアニメーション化する場合は、`targetShape` の代わりに対象オブジェクトを [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) に渡してください。チャート固有のグループ化オプションについては、[Animated Charts](/slides/ja/androidjava/animated-charts/) を参照してください。

## **図形アニメーションの取得**

対象シェイプが分かっている場合は、[ISequence.getEffectsByShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) を使用します。すべてのエフェクトを調べるには、メイン シーケンスとすべてのインタラクティブ シーケンスを列挙します。列挙することで、シーケンスのインデックス `0` にエフェクトが必ず存在するという前提を避けられます。

次の例はメイン シーケンスとインタラクティブ シーケンスにエフェクトを持つシェイプを作成し、そのシェイプを対象とするエフェクトを取得したうえで、スライド上のすべてのシーケンスを列挙します。

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

1 つのシェイプに対するエフェクトだけが必要な場合は、名前、プレースホルダーの種類、またはその他の安定したプロパティでシェイプを特定し、[ISequence.getEffectsByShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) を呼び出してください。インデックス `0` の [IShapeCollection.get_Item](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) が常に目的のオブジェクトであると仮定しないでください。

## **継承プレースホルダー エフェクトの操作**

通常スライド上のプレースホルダーは、レイアウト スライドおよびマスタースライド上の対応するプレースホルダーからアニメーション 動作を継承できます。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) は親プレースホルダーを返すか、親が存在しない場合は `null` を返します。

以下の例示プレゼンテーションでは、フッターが通常スライドで **Random Bars**、レイアウト スライドで **Split**、マスタースライドで **Fly In** のアニメーションを持ちます。

![通常スライドのフッター アニメーション効果](slide-shape-animation.png)

![レイアウト スライドのフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライドのフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例は新規プレゼンテーションのプレースホルダー階層を使用します。マスタープレースホルダー、レイアウトプレースホルダー、そして通常スライド上の対応するプレースホルダーにエフェクトを追加します。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) の戻り値が `null` でないことを確認してから使用します。

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **アニメーション タイミングの変更**

PowerPoint の **Timing** ダイアログは [ITiming](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/) のプロパティに対応しています。

![アニメーション エフェクトの PowerPoint Timing ダイアログ](shape-animation.png)

- **Start** は [ITiming.getTriggerType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getTriggerType--) に対応します。  
- **Duration** は [ITiming.getDuration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getDuration--) に対応し、単位は秒です。  
- **Delay** は [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) に対応し、単位は秒です。  
- **Repeat** は [ITiming.getRepeatCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatCount--) 、[ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--)、または [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) のいずれかに対応します。  
- **Rewind when done playing** は [ITiming.getRewind](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRewind--) に対応します。

この独立した例はエフェクトを追加し、[ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) が返すオブジェクトでタイミングを変更したうえで、結果を保存します。返された [IEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/) 参照を保持することで不要なコレクション インデックス取得を回避できます。

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

繰り返しモードは 1 つだけ使用してください。繰り返し回数と「until」フラグを組み合わせると、ビューアによって結果が混乱する可能性があります。繰り返しモードを変更する際は、[ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) と [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) を先に設定し、次に [ITiming.setRepeatCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) を呼び出してください。いずれかのフラグを設定すると、アクティブな繰り返しモードが自動的に変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーション エフェクトは [IEffect.getSound](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getSound--) を介して埋め込み音声を参照できます。[IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) は、以前のエフェクトで開始された音声を停止させるために使用します。

### **エフェクトにサウンドを追加する**

以下の例はローカルのオーディオ ファイル `animation-sound.wav` を前提とします。2 つのエフェクトを作成し、最初のエフェクトにこのファイルをサウンドとして埋め込み、2 番目のエフェクトでサウンドの停止を設定します。オブジェクトは [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) が返すものを使用するため、シーケンス インデックスは不要です。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **埋め込みエフェクトサウンドの抽出**

以下の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` を前提とします。メインとインタラクティブの両シーケンスを走査し、埋め込まれたエフェクトサウンドをすべて `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [IAudio.getContentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudio/#getContentType--) が返すオーディオ MIME タイプから決定します。

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

大容量のオーディオ オブジェクトの場合は、[IAudio.getStream](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudio/#getStream--) を使用してストリームをファイルにコピーし、全体をバイト配列に読み込むのは避けてください。

## **アフター アニメーション 動作の設定**

**After animation** オプションは、エフェクトが完了した後のシェイプの状態を制御します。

![After animation 設定を示す PowerPoint Effect Options ダイアログ](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/) クラスは、シェイプをそのまま残す、色を変更する、アニメーション後に非表示にする、または次のクリックで非表示にするといった動作をサポートします。タイプが [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#Color) の場合は、[IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクト オブジェクトでアフター アニメーション 動作を設定したうえで、結果を保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#Color) 以外のタイプに変更すると、アフター アニメーションの色設定はクリアされます。

## **テキストのアニメーション**

テキスト アニメーションには 2 つの関連コントロールがあります。

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextanimation/#getBuildType--) は、段落単位で表示するか、全体として表示するかを制御します。  
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) は、テキストを一括表示、単語単位、文字単位のいずれで表示するかを制御します。[IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) は単語または文字間の遅延を設定します。正の値はエフェクト時間のパーセンテージ、負の値は秒単位の遅延です。

以下の独立した例はテキスト ボックス内の単語をアニメーション化します。[BuildType.AsOneObject](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/buildtype/#AsOneObject) を使用すると段落ごとのビルドが無効化され、単語設定がテキスト フレーム全体に適用されます。

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

テキスト ボックスを段落単位でビルドしたい場合は、[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1)（または他の段落レベル）を設定してください。個別の段落に対して独自のエフェクトを設定したい場合は、[IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) を受け取る [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) のオーバーロードを使用します。段落レベルの例については [Animated Text](/slides/ja/androidjava/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX 形式で保存するとアニメーション モデルは保持されますが、最終的な再生はプレゼンテーション ビューアが制御します。  
- PDF や静的画像はアニメーションを再生しません。モーションを保持する必要がある場合は、[HTML5 エクスポート](/slides/ja/androidjava/export-to-html5/)、アニメーション GIF、または [ビデオ変換](/slides/ja/androidjava/convert-powerpoint-to-video/) を使用してください。  
- HTML5 では [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) を有効にし、必要に応じて [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) も有効にしてください。  
- ビデオ変換は多くの一般的な「入場」「強調」「退出」「モーション パス」エフェクトをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の [サポート対象アニメーションとエフェクト](/slides/ja/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。  
- カスタム エフェクトや他形式からインポートされたエフェクトはファイル内に保持される場合がありますが、PowerPoint、HTML5、ビデオでのレンダリング結果が異なることがあります。エフェクト名だけに依存せず、エクスポート結果を必ず検証してください。

## **FAQ**

**なぜ PowerPoint ではアニメーションが表示されても PDF では表示されないのですか？**

PDF は静的形式であるため、アニメーションやスライド遷移は再生されません。モーションを保持したい場合は HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**なぜビデオでエフェクトの再生が異なるのですか？**

ビデオ エクスポートはアニメーションを描画した結果を保存するもので、元の PowerPoint の動作そのものを保持するわけではありません。一部の高度なエフェクトは未サポートまたは近似処理されます。サポート対象エフェクト表を確認し、実際のプレゼンテーションをテストしてから本番で使用してください。

**シェイプを前面または背面に移動するとアニメーションの順序が変わりますか？**

変わりません。シェイプの Z オーダーは重なり順を制御し、シーケンス順序とトリガーがアニメーションの再生順序を決定します。再生順序を変更したい場合はタイムラインを調整してください。