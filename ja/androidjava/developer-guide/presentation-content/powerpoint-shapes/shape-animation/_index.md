---
title: Android でのプレゼンテーションにシェイプ アニメーションを適用する
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
description: "Aspose.Slides for Android (Java) を使用して、シェイプ アニメーション、タイミング、サウンド、アフター アニメーション 動作、アニメーション テキストの追加、検査、カスタマイズ方法を学びます。"
---
## **概要**

エフェクト内の個々の動作やモーション パス セグメントを編集するには、[Java 用カスタム アニメーション](/slides/ja/java/custom-animation/) を参照してください。

Java 経由の Aspose.Slides for Android は、スライド アニメーションをスライド タイムライン上のエフェクトとして表します。エフェクトには対象シェイプ、アニメーションの種類とサブタイプ、トリガー、タイミング設定、そしてサウンドやアフター アニメーション動作などのオプション プロパティがあります。

タイムラインには次の 2 種類のシーケンスがあります。

- **メイン シーケンス** はスライドが進むと再生されます。
- **インタラクティブ シーケンス** はトリガーシェイプがクリックされたときに開始します。

テキスト ボックス、画像、チャート、テーブル、その他のスライド オブジェクトは [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) を実装しているため、ほとんどのスライド コンテンツに対して同じ [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) メソッドを使用します。利用可能なエフェクトは [EffectType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttype/) クラスに一覧されています。

## **シェイプ アニメーションの追加**

アニメーションを追加するには、スライドのメイン シーケンスを取得し、対象シェイプ、エフェクト タイプ、サブタイプ、トリガーを指定して [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) を呼び出します。他のシェイプがクリックされたときに開始するエフェクトの場合、そのシェイプをトリガーとするインタラクティブ シーケンスを作成します。

次の例は 2 種類のアニメーションを作成し、結果を `shape-animations.pptx` に保存します。

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttriggertype/#OnClick) はメイン シーケンスでのクリック、またはインタラクティブ シーケンスでのトリガーシェイプのクリックを待ちます。
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) は直前のエフェクトと同時に開始します。
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) は直前のエフェクトが終了したときに開始します。

画像、チャート、その他のシェイプ タイプをアニメーション化するには、`targetShape` の代わりにそのオブジェクトを [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) に渡します。チャート固有のグループ化オプションについては、[Animated Charts](/slides/ja/androidjava/animated-charts/) を参照してください。

## **シェイプ アニメーションの取得**

対象シェイプが分かっている場合は [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) を使用します。すべてのエフェクトを調べるには、メイン シーケンスとすべてのインタラクティブ シーケンスを列挙します。列挙することで、シーケンスがインデックス `0` にエフェクトを含んでいると仮定することを防げます。

次の例はメイン シーケンスとインタラクティブ シーケンスを持つシェイプを作成し、そのシェイプを対象としたエフェクトを取得し、スライド上のすべてのシーケンスを列挙します。

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

1 つのシェイプだけのエフェクトが必要な場合は、まずシェイプを名前、プレースホルダー タイプ、または他の安定したプロパティで特定し、次に [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) を呼び出します。[IShapeCollection.get_Item](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) のインデックス `0` が常に目的のオブジェクトであると想定しないでください。

## **継承プレースホルダー エフェクトの操作**

通常のスライド上のプレースホルダーは、レイアウト スライドおよびマスタースライド上の対応するプレースホルダーからアニメーション 動作を継承できます。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) は親プレースホルダーを返し、存在しない場合は `null` を返します。

以下の例示プレゼンテーションでは、フッターが通常のスライドで **Random Bars**、レイアウトスライドで **Split**、マスタースライドで **Fly In** のアニメーションを持っています。

![通常のスライドのフッター アニメーション効果](slide-shape-animation.png)

![レイアウト スライドのフッター プレースホルダー アニメーション効果](layout-shape-animation.png)

![マスタースライドのフッター プレースホルダー アニメーション効果](master-shape-animation.png)

次の例は新規プレゼンテーションのプレースホルダー階層を使用します。マスタープレースホルダー、レイアウトプレースホルダー、対応する通常スライド上のプレースホルダーにエフェクトを追加し、各呼び出しで [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) の戻り値が `null` でないことを確認しています。

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

PowerPoint **タイミング** ダイアログは [ITiming](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/) のプロパティに対応します。

![アニメーション エフェクトの PowerPoint タイミング ダイアログ](shape-animation.png)

- **開始** は [ITiming.getTriggerType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getTriggerType--) に対応します。
- **期間** は [ITiming.getDuration](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getDuration--) に対応し、秒単位です。
- **遅延** は [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--) に対応し、秒単位です。
- **繰り返し** は [ITiming.getRepeatCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatCount--) 、[ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--)、または [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) に対応します。
- **再生完了後に巻き戻す** は [ITiming.getRewind](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#getRewind--) に対応します。

この独立した例はエフェクトを追加し、[ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) が返すオブジェクトを通してタイミングを変更し、結果を保存します。返された [IEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/) 参照を保持することで、不必要なコレクション インデックス取得を回避できます。

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

繰り返しモードは 1 つだけ使用してください。繰り返し回数と「until」フラグを組み合わせると、ビューアー間で混乱を招く結果になることがあります。繰り返しモードを変更する際は、[ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) と [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) を [ITiming.setRepeatCount](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-) の前に設定してください。どちらかのフラグを設定するとアクティブな繰り返しモードも変更されます。

## **アニメーション サウンドの追加と抽出**

アニメーション エフェクトは [IEffect.getSound](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getSound--) で埋め込まれたオーディオを参照できます。[IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) は、以前のエフェクトで開始したサウンドを停止させます。

### **エフェクトにサウンドを追加する**

以下の例はローカルのオーディオ ファイル `animation-sound.wav` を想定しています。2 つのエフェクトを作成し、最初のエフェクトにそのファイルをサウンドとして埋め込み、2 番目のエフェクトをサウンド停止に設定します。[ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) が返すオブジェクトを使用するため、シーケンス インデックスは不要です。

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

### **埋め込みエフェクト サウンドの抽出**

以下の例はローカルのプレゼンテーション `presentation-with-animation-sounds.pptx` を想定しています。メイン シーケンスとインタラクティブ シーケンスの両方を走査し、埋め込まれたエフェクト サウンドをすべて `extracted-animation-sounds` ディレクトリに書き出します。拡張子は [IAudio.getContentType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudio/#getContentType--) が返すオーディオ MIME タイプから選択されます。

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

大きなオーディオ オブジェクトの場合は、[IAudio.getStream](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudio/#getStream--) を使用してストリームをファイルにコピーし、オブジェクト全体をバイト配列に読み込むのを避けてください。

## **アフター アニメーション 動作の設定**

**After animation** オプションはエフェクトが終了した後のシェイプの状態を制御します。

![PowerPoint エフェクト オプション ダイアログ (After animation 設定)](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/) クラスは、シェイプをそのまま残す、色を変更する、アニメーション後に非表示にする、次のクリックで非表示にする、のいずれかをサポートします。タイプが [AfterAnimationType.Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#Color) の場合は、[IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--) も設定してください。

この独立した例はエフェクトを作成し、返されたエフェクト オブジェクトを通してアフター アニメーション 動作を設定し、結果を保存します。

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

[AfterAnimationType.Color](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/afteranimationtype/#Color) 以外に変更すると、アフター アニメーションのカラー設定はクリアされます。

## **テキストのアニメーション化**

テキスト アニメーションには 2 つの関連コントロールがあります。

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextanimation/#getBuildType--) は段落単位で表示するか、全体として表示するかを制御します。
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) はテキストを一括、単語単位、文字単位のいずれで表示するかを制御します。[IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) は単語または文字間の遅延を設定します。正の値はエフェクト期間のパーセンテージ、負の値は秒単位の遅延です。

次の独立した例はテキスト ボックス内の単語をアニメーション化します。[BuildType.AsOneObject](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/buildtype/#AsOneObject) を使用すると段落単位のビルドが無効になり、単語設定がテキスト フレーム全体に適用されます。

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

段落単位でテキスト ボックスをビルドするには、[BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1)（または他の段落レベル）を設定します。特定の段落に個別のエフェクトを適用するには、[IParagraph](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iparagraph/) を受け取る [ISequence.addEffect](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) のオーバーロードを使用します。段落レベルの例については [Animated Text](/slides/ja/androidjava/animated-text/) を参照してください。

## **エクスポートと互換性に関する注意事項**

- PPT または PPTX に保存するとアニメーション モデルは保持されますが、最終的な再生はプレゼンテーション ビューアーによって制御されます。
- PDF や静止画像はアニメーションを再生しません。モーションを保持する必要がある場合は、[HTML5 エクスポート](/slides/ja/androidjava/export-to-html5/)、アニメーション GIF、または [動画変換](/slides/ja/androidjava/convert-powerpoint-to-video/) を使用してください。
- HTML5 では [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) を有効にし、必要に応じて [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) も設定します。
- ビデオレンダリングは多くの一般的な入場、強調、退出、モーション パス エフェクトをサポートしますが、すべての PowerPoint エフェクトがサポートされているわけではありません。現在の [サポートされているアニメーションとエフェクト](/slides/ja/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) を確認し、対象の Aspose.Slides バージョンで重要なプレゼンテーションをテストしてください。
- カスタム エフェクトや他のプレゼンテーション フォーマットからインポートされたエフェクトは、ファイル内に保持されるものの、PowerPoint、HTML5、またはビデオでの描画が異なる場合があります。エフェクト名だけに依存せず、エクスポート結果を検証してください。

## **FAQ**

**PowerPoint では表示されるのに PDF では表示されないのはなぜですか？**

PDF は静的フォーマットであるため、アニメーションやスライド遷移は再生されません。モーションを保持する必要がある場合は、HTML5、アニメーション GIF、またはビデオにエクスポートしてください。

**動画でエフェクトの再生が異なるのはなぜですか？**

動画エクスポートはアニメーションをレンダリングするもので、元の PowerPoint の動作をそのまま保存するわけではありません。高度なエフェクトの一部は未サポートまたは近似されます。サポートされているエフェクトの表を確認し、実際のプレゼンテーションをテストしてから本番で使用してください。

**シェイプを前面または背面に移動するとアニメーション順序が変わりますか？**

いいえ。シェイプの Z オーダーは重なり順を制御し、シーケンス順序とトリガーがアニメーションの再生順序を制御します。再生順序を変更したい場合はタイムラインを調整してください。