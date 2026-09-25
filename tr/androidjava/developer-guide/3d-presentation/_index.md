---
title: Android'de Sunumlar İçin 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/androidjava/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B döndürme
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides ile Android üzerinde PowerPoint şekilleri ve metni için 3B efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgu ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Android via Java can create, edit, preserve, and render PowerPoint-style 3D formatting for shapes and text. This article covers 3D effects such as rotation, extrusion, bevels, lighting, material, gradient or picture fills, and 3D text.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Bağımsız 3B model dosyalarını ekleme veya düzenleme ile ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılmış 2B çıktıya işler.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Use the [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) method to apply 3D formatting to a shape. The method returns [IThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/), which controls the 3D scene for that shape.

For text, use the [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) method. This applies 3D formatting to the text frame instead of the shape body.

The most important API members are:

| API üyesi | Kontrol ettiği şey | Ne zaman kullanılmalı |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Bakış noktası, ön ayarlı kamera türü, dönüş, yakınlaştırma ve perspektif. | Nesneyi 3B alanda döndürmek veya bir PowerPoint 3B dönüş ön ayarını eşleştirmek. |
| [getLightRig](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Işık ön ayarı, yön ve ışık dönüşü. | Vurguların ve gölgelerin 3B yüzeyde nasıl göründüğünü değiştirmek. |
| [getMaterial](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Yüzey malzemesi, düz, mat, plastik veya metal gibi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak. |
| [getExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Şeklin ön yüzünden geriye ne kadar uzandığını. | Düz bir şekli net bir şekilde kalın bir 3B nesne haline getirmek. |
| [getExtrusionColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Ekstrüde edilen yanların rengi. | Derinliği görünür kılmak veya yan rengini ön dolguyla eşleştirmek. |
| [getDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3B biçimlendirmesinde kullanılan ek 3B derinlik. | Şekiller veya metinler için, özellikle köşe ve malzeme ayarlarıyla birlikte derinliği ince ayarlamak. |
| [getBevelTop](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşatılmış veya kalıplanmış bir kenar eklemek. |
| [getContourColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3B nesnenin etrafındaki kontur. | Render edilen çıktıda nesne sınırını vurgulamak. |

## **3B Şekil Oluşturma**

A shape usually needs four kinds of settings before it looks convincingly 3D:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların görülebilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl yansıtıldığını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

The following example creates a rectangle, adds text to its front face, and applies 3D formatting. The camera rotation values are in degrees, and the extrusion height is 100 points. The example renders the slide to a PNG image at twice its default dimensions and saves the presentation as PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The rendered slide image shows the rectangle as a thick 3D block:

![Ön yüzünde beyaz 3B metinli mavi 3B dikdörtgen render edildi](img_01_01.png)

## **Kamera ile Şekli Döndürme**

In PowerPoint, 3D rotation is configured from the 3-D Rotation pane. The X, Y, and Z rotation values correspond to the rotation you set through the camera API.

![X, Y ve Z dönüş değerlerinin vurgulandığı PowerPoint 3-B Dönüş bölmesi](img_02_01.png)

In Aspose.Slides, access the camera through [IThreeDFormat.getCamera](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getCamera--). This example creates a rectangle, selects an orthographic front view, and sets its X, Y, and Z rotations to 20, 30, and 40 degrees, respectively. It configures the shape in memory without saving a file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Use the camera when you need to change how the viewer sees the object. It does not change the 2D shape geometry on the slide. It changes the 3D viewpoint used by PowerPoint and by Aspose.Slides when rendering.

## **Ekstrüzyon ve Derinlik Ekleme**

Extrusion makes a shape look thick by extending it behind the front face. In PowerPoint, the depth control sets this visible thickness, and the color control sets the color of the side faces.

![PowerPoint derinlik kontrolleri ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlendi](img_02_02.png)

Use [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) to set the thickness and [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) to access the side color. This example gives a rectangle a 100-point extrusion with purple sides and rotates the camera to reveal its thickness. It configures the shape in memory without saving a file:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

The [IThreeDFormat.setDepth](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) method sets the depth of a 3D shape. The [setExtrusionHeight](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) method controls the height of the extrusion effect, as shown in this example.

## **3B Efektlerle Degrade veya Resim Dolguları Kullanma**

3D formatting is independent of the shape fill. You can apply a solid color, gradient, pattern, or picture fill to the front face and still use the same camera, light, material, and extrusion settings.

This example applies a blue-to-orange gradient to the front face and a dark orange color to the 150-point extrusion. The gradient stops at 0 and 100 mark the start and end of the gradient. The camera rotation values are in degrees. The slide is rendered to a PNG image at twice its default dimensions:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

The rendered output keeps the gradient on the front face and renders the extrusion separately:

![Mavi- turuncu degrade dolgu ve turuncu ekstrüzyonlu 3B dikdörtgenin renderı](img_02_03.png)

To use a picture fill instead, add the image to the presentation and assign it to the shape fill. This example requires an existing file named "image.jpg" in the working directory. It stretches the picture to fill the rectangle, applies a 150-point extrusion, and sets the camera rotation in degrees. It configures the shape in memory without saving or rendering a file:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

The picture is rendered on the front face, while the extrusion is rendered as the 3D side surface:

![Ön yüzünde fotoğraf dolgulu ve turuncu ekstrüzyonlu 3B dikdörtgenin renderı](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Shape 3D formatting affects the shape body. Text 3D formatting affects the text frame. This is useful for WordArt-like effects where the letters themselves need extrusion, material, lighting, and camera settings.

The following example creates text with an orange-and-white grid pattern, applies an upward arch, and configures 3D settings through [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). The extrusion height and depth are in points, and the light rotation is in degrees. The shape fill and outline are hidden so that only the text is visible. The example renders a PNG image at twice the default slide dimensions and saves the presentation as PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    int patternColor = Color.rgb(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

The text is rendered as curved, extruded 3D lettering:

![Kemerli WordArt dönüşümü, turuncu desen dolgusu ve koyu ekstrüzyonlu 3B metnin renderı](img_02_05.png)

## **3B Şekilde Metni Düz Tutma**

To keep text readable while preserving a shape's 3D appearance, call [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) through [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). When the value is `true`, the text stays out of the 3D scene. When it is `false`, the text participates in the scene and follows its 3D orientation.

This setting does not remove the shape's 3D formatting: its camera, lighting, material, and extrusion remain configured through [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). It is also different from ordinary rotation. [IShape.setRotation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#setRotation-float-) rotates the shape in the slide plane, while [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) controls the text's custom rotation within its bounding box. Keeping text out of the 3D scene does not reset either of those angles.

The following self-contained example creates a blue rectangle with text and clones it beside the original. Both shapes have the same 3D formatting; only the text setting differs: `false` on the left and `true` on the right. The camera angles are in degrees, and the extrusion height is 40 points. The example saves the presentation as PPTX and renders the comparison slide to PNG at twice its default dimensions.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

On the left, the text follows the 3D orientation. On the right, it stays flat and easier to read. Both rectangles retain the same visible extrusion and 3D orientation.

![Yan yana 3B dikdörtgenler: solda metin 3B yönelime göre, sağda ise düz kalır](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides preserves 3D formatting when saving to PowerPoint formats such as PPTX. When rendering or exporting to fixed-layout formats, the 3D scene is rasterized or drawn into the output as a 2D result. This applies when you render slides to [PNG](/slides/tr/androidjava/convert-powerpoint-to-png/), export to [PDF](/slides/tr/androidjava/convert-powerpoint-to-pdf/), export to [HTML](/slides/tr/androidjava/convert-powerpoint-to-html/), or generate frames for [video conversion](/slides/tr/androidjava/convert-powerpoint-to-video/).

Keep these points in mind:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne, dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık seti, malzeme, ekstrüzyon, dolgu ve slayt ölçeklemesinin kombinasyonuna bağlıdır.
- Kalıtılan veya tema tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkin şekil özelliklerini](/slides/tr/androidjava/shape-effective-properties/) okuyun.
- Bazı çıktı biçimleri düzenlenebilir PowerPoint 3B biçimlendirmesini depolayamaz. Bu biçimlerde görsel sonuç, düzenlenebilir 3B ayarlar olarak korunmak yerine render edilir.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides PowerPoint şekilleri ve metni için 3B efektleri oluşturur ve render eder. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX formatında, 3B biçimlendirme destekleyen PowerPoint uygulamasında düzenlenebilir olarak kalır.

**Bir 3B model ile 3B efekt arasındaki fark nedir?**

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt, bir PowerPoint şekli veya metnine uygulanan (dönme, ekstrüzyon, köşe, aydınlatma, malzeme vb.) biçimlendirmedir. Bu makale 3B efektleri kapsar.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En az bir kamera dönüşü ve ya ekstrüzyon ya da derinlik ayarlanmalıdır. Pratikte, render edilen yüzeylerin net vurgular ve gölgeler alması için bir ışık seti ve malzeme de eklenir.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [IShape.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) ve metin için [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) kullanın.

**Görüntülere, PDF, HTML veya video karelerine dışa aktarırken 3B efektler görünecek mi?**

Evet. Aspose.Slides slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretilirken 3B efektleri render eder. Dışa aktarılan çıktı render edilmiş görünümü içerir, düzenlenebilir bir 3B nesne değildir.

**Kalıtım ve tema ayarları uygulandıktan sonra son 3B değerleri okuyabilir miyim?**

Evet. Son kamera, ışık seti, köşe ve ilgili 3B değerlerini okumak için [Şekil Etkin Özellikleri](/slides/tr/androidjava/shape-effective-properties/) bölümünde açıklanan etkili biçimlendirme API'lerini kullanın.