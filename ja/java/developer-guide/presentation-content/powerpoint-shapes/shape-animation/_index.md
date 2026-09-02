---
title: Java を使用したプレゼンテーションへのシェイプ アニメーションの適用
linktitle: シェイプ アニメーション
type: docs
weight: 60
url: /ja/java/shape-animation/
keywords:
- シェイプ
- アニメーション
- エフェクト
- アニメーション シェイプ
- アニメーション テキスト
- アニメーション 追加
- アニメーション 取得
- アニメーション 抽出
- エフェクト 追加
- エフェクト 取得
- エフェクト 抽出
- エフェクト サウンド
- アニメーション 適用
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、シェイプ アニメーションの追加、検査、カスタマイズ、タイミング、サウンド、アフターアニメーション 動作、アニメーション テキストを学びます。"
---
## **概要**

Aspose.Slides for Java は、スライド上のアニメーションをスライドタイムライン上のエフェクトとして表現します。エフェクトは対象シェイプ、アニメーションの種類とサブタイプ、トリガー、タイミング設定、およびサウンドやアフターアニメーション動作といったオプションプロパティを持ちます。

タイムラインには 2 種類のシーケンスがあります。

- **メイン シーケンス** はスライドが進むときに再生されます。
- **インタラクティブ シーケンス** はトリガーシェイプがクリックされたときに開始します。

テキスト ボックス、画像、チャート、テーブルなどのスライド オブジェクトはすべて [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) を実装しているため、ほとんどのコンテンツに対して同じ [ISequence.addEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effecttype/) クラスに列挙されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、対象シェイプ、エフェクトの種類、サブタイプ、トリガーを指定して [ISequence.addEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) を呼び出します。別のシェイプをクリックしたときに開始するエフェクトの場合は、そのシェイプをトリガーとしたインタラクティブ シーケンスを作成します。

以下の例は 2 種類のアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effecttriggertype/#OnClick) はメイン シーケンスではクリックを待ち、インタラクティブ シーケンスではトリガー シェイプのクリックを待ちます。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effecttriggertype/#WithPrevious) は直前のエフェクトと同時に開始します。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ja/java/com.aspose.slides/effecttriggertype/#AfterPrevious) は直前のエフェクトが終了したときに開始します。

画像、チャート、その他のシェイプをアニメーション化する場合は、`targetShape` の代わりに対象オブジェクトを [ISequence.addEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) に渡します。チャート固有のグループ化オプションについては [Animated Charts](/slides/ja/java/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

対象シェイプが分かっている場合は、[ISequence.getEffectsByShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) を使用します。すべてのエフェクトを確認したいときは、メイン シーケンスとすべてのインタラクティブ シーケンスを列挙します。列挙により、インデックス `0` にエフェクトが必ず存在するという前提を回避できます。

以下の例は、メイン シーケンスとインタラクティブ シーケンスにエフェクトを持つシェイプを作成し、そのシェイプを対象としたエフェクトを取得した後、スライド上のすべてのシーケンスを列挙します。

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

1 つのシェイプだけのエフェクトが必要な場合は、まず名前、プレースホルダーの種類、または他の安定したプロパティでシェイプを特定し、[ISequence.getEffectsByShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) を呼び出します。インデックス `0` の [IShapeCollection.get_Item](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/#get_Item-int-) が常に目的のオブジェクトであるとは限らないことに注意してください。

## **継承プレースホルダー エフェクトの操作**

通常スライドのプレースホルダーは、レイアウト スライドおよびマスタースライド上の対応するプレースホルダーからアニメーション動作を継承できます。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getBasePlaceholder--) は、親プレースホルダーを返すか、存在しなければ `null` を返します。

以下のサンプル プレゼンテーションでは、フッターが通常スライドで **Random Bars**、レイアウト スライドで **Split**、マスタースライドで **Fly In** のアニメーションを持ちます。

![通常スライドのフッター アニメーション効果](slide-shape-animation.png)

![レイアウト スライドのフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライドのフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例は新しいプレゼンテーションのプレースホルダー階層を使用します。マスタープレースホルダー、レイアウトプレースホルダー、通常スライド上の対応するプレースホルダーにエフェクトを追加し、[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/#getBasePlaceholder--) の戻り値が `null` でないことを確認してから使用します。

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

PowerPoint の **Timing** ダイアログは [ITiming](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/) のプロパティに対応します。

![アニメーション効果の PowerPoint Timing ダイアログ](shape-animation.png)

- **Start** は [ITiming.getTriggerType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getTriggerType--) にマッピングされます。
- **Duration** は [ITiming.getDuration](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getDuration--) にマッピングされ、単位は秒です。
- **Delay** は [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getTriggerDelayTime--) にマッピングされ、単位は秒です。
- **Repeat** は [ITiming.getRepeatCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getRepeatCount--)、[ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--)、または [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) にマッピングされます。
- **Rewind when done playing** は [ITiming.getRewind](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#getRewind--) にマッピングされます。

この独立した例はエフェクトを追加し、[ISequence.addEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) が返すオブジェクトでタイミングを変更し、結果を保存します。返された [IEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/) 参照を保持することで、不要なコレクション インデックス参照を回避できます。

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

繰り返しモードは意図的に 1 つだけ使用してください。繰り返し回数と「until」フラグを同時に設定すると、ビューアーごとに結果が混乱する可能性があります。繰り返しモードを変更する際は、[ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) と [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) を [ITiming.setRepeatCount](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itiming/#setRepeatCount-float-) の前に呼び出してください。いずれかのフラグを設定すると、アクティブな繰り返しモードが自動的に変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーション エフェクトは [IEffect.getSound](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getSound--) を通じて埋め込みオーディオを参照できます。[IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) は、エフェクトが以前のエフェクトで開始されたサウンドを停止するよう指示します。

### **エフェクトにサウンドを追加**

以下の例はローカルのオーディオ ファイル `animation-sound.wav` を使用します。2 つのエフェクトを作成し、最初のエフェクトにこのファイルをサウンドとして埋め込み、2 番目のエフェクトでサウンドを停止するよう構成します。シーケンス インデックスは不要で、[ISequence.addEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) が返すオブジェクトを使用します。

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

以下の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` を使用します。メインとインタラクティブ シーケンスの両方を走査し、埋め込まれたエフェクトサウンドをすべて `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [IAudio.getContentType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaudio/#getContentType--) が返す MIME タイプから選択されます。

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

大容量のオーディオ オブジェクトの場合は、[IAudio.getStream](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iaudio/#getStream--) を使用してストリームをファイルにコピーし、全体をバイト配列に読み込むのを避けてください。

## **アフターアニメーション 動作の設定**

**After animation** オプションは、エフェクトが終了した後にシェイプに対して何が起こるかを制御します。

![PowerPoint Effect Options ダイアログの After animation 設定](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/) クラスは、シェイプをそのまま残す、色を変える、アニメーション後に非表示にする、あるいは次のクリックで非表示にする、という動作をサポートします。タイプが [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/#Color) の場合は、[IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクト オブジェクトでアフターアニメーション 動作を設定し、結果を保存します。

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/ja/java/com.aspose.slides/afteranimationtype/#Color) 以外のタイプに変更すると、アフターアニメーションのカラー設定はクリアされます。

## **テキストのアニメーション**

テキスト アニメーションには次の 2 つの関連コントロールがあります。

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextanimation/#getBuildType--) は、段落全体を一度に表示するか段落単位で表示するかを制御します。
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getAnimateTextType--) は、テキストを一括で表示するか単語単位か文字単位かを制御します。[IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) は単語または文字間の遅延を設定します。正の値はエフェクト時間のパーセンテージ、負の値は秒単位の遅延です。

以下の独立した例はテキスト ボックス内の単語をアニメーション化します。[BuildType.AsOneObject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/buildtype/#AsOneObject) を使用して段落単位のビルドを無効にし、単語設定がテキスト フレーム全体に適用されるようにします。

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

段落単位でテキスト ボックスをビルドしたい場合は、[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ja/java/com.aspose.slides/buildtype/#ByLevelParagraphs1)（または他の段落レベル）を設定してください。単一の段落に独自のエフェクトを適用するには、[ISequence.addEffect](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) のオーバーロードで [IParagraph](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iparagraph/) を受け取ります。段落レベルの例については [Animated Text](/slides/ja/java/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意**

- PPT または PPTX で保存するとアニメーション モデルは保持されますが、最終的な再生はプレゼンテーション ビューアーに依存します。
- PDF や静止画像はアニメーションを再生しません。モーションを示す必要がある場合は、[HTML5 エクスポート](/slides/ja/java/export-to-html5/)、アニメーション GIF、または [動画変換](/slides/ja/java/convert-powerpoint-to-video/) を使用してください。
- HTML5 では [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) を有効にし、必要に応じて [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) も有効にしてください。
- ビデオ レンダリングは多数の一般的な入場、強調、退出、モーションパス エフェクトをサポートしますが、すべての PowerPoint エフェクトが対象になるわけではありません。現在の [サポートされているアニメーションとエフェクト](/slides/ja/java/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。
- カスタム エフェクトや他のプレゼンテーション形式からインポートされたエフェクトはファイル内に保持される場合がありますが、PowerPoint、HTML5、またはビデオでのレンダリングが異なることがあります。エフェクト名だけに依存せず、エクスポート結果を必ず検証してください。

## **FAQ**

**なぜアニメーションは PowerPoint では表示されるのに PDF では表示されないのですか？**

PDF は静的形式であるため、アニメーションやスライド遷移は再生されません。モーションを保持したい場合は、HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**なぜエフェクトはビデオで再生が異なるのですか？**

ビデオ エクスポートはアニメーションをレンダリングして保存し、元の PowerPoint 動作をそのまま保持しません。一部の高度なエフェクトは未サポートまたは近似されます。サポートされているエフェクト一覧を確認し、実際のプレゼンテーションでテストしてください。

**シェイプを前面または背面に移動するとアニメーションの順序が変わりますか？**

変更されません。シェイプの Z オーダーは重なり順を制御し、シーケンス順序とトリガーがアニメーション再生順を制御します。再生順序を変更したい場合はタイムラインを調整してください。