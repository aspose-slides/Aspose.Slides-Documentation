---
title: Android'de Sunum Şekillerini Özelleştir
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/androidjava/custom-shape/
keywords:
- özel şekil
- şekil ekle
- şekil oluştur
- şekil değiştir
- şekil geometrisi
- geometri yolu
- yol noktaları
- nokta düzenle
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- yuvarlatılmış köşe
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, yuvarlatılmış köşeler, bileşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta şekil geometrisini düzenleme noktaları ve geometri yolları aracılığıyla özelleştirmenin yollarını açıklar. [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) kullanarak mevcut şekilleri değiştirmeyi, temel yol düzenleme işlemlerini gerçekleştirmeyi, nokta eklemeyi veya kaldırmayı ve güncellenmiş geometrinin bir şekle uygulanmasını gösterir.

Ayrıca, özel ve bileşik şekiller oluşturmayı, köşeleri yuvarlatılmış şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi ve Android nokta dizileri kullanarak şekil öğelerini incelemeyi de örneklerle anlatır.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirin**

PowerPoint'te bir kareyi değiştirmek için **Düzenleme Noktaları**nı kullanabilirsiniz:

* Bir köşeyi içe veya dışa doğru hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin konturunu değiştirmenize veya mevcut bir şekli yeni bir şeklin temel olarak kullanmanıza olanak tanır.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda tutun:

* Bir şeklin (veya yolunun) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan çapa noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Çapa noktaları ve kontrol kulpları şeklin şeklini belirler.
* Çapa noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Bir köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Bir yumuşak noktada, iki kontrol kulpu hizalanmış ve çapa noktasından eşit uzaklıktadır.
  * Bir düz noktada, iki kontrol kulpu hizalanmış ancak çapa noktasına farklı uzaklıklarda olabilir.
* Çapa noktalarını hareket ettirmek veya kulplarını ayarlamak şeklin konturunu değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) sınıfını ve [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) arayüzünü sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) örneği, [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) nesnesinin geometri yolunu temsil eder.
* [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) almak için [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) metodunu kullanabilirsiniz.
* Bir şekle [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) ayarlamak için tek yollu şekillerde [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) metodunu, çok yollu şekillerde ise [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) metodunu kullanabilirsiniz.
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) altındaki metodları kullanabilirsiniz.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) ve [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) metodlarıyla bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) metodu, bir [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) yolunu yol segmentleri dizisi olarak döndürür.

## **Basit Düzenleme İşlemleri**

Aşağıdaki metodları kullanarak bir geometri yolunu düzenleyin. Bir indeksi kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki sıfır‑tabanlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekleyin veya ekleyin. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| İki kontrol noktası ve bir bitiş noktasıyla bir kübik Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Tek bir kontrol noktası ve bir bitiş noktasıyla bir ikili Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Belirtilen boyut ve derecedeki açılarıyla eliptik bir yay ekleyin. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Bitiş noktasını başlangıç noktasına bağlayarak geçerli figürü kapatın. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Bir figürün başlangıç noktasını ayarlayın. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Sıfır‑tabanlı bir indekste bir segmenti kaldırın. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Bir Şekle Özel Noktalar Ekleyin**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) metodunu kullanır ve düzenlenmiş yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygular. Koordinatlar şekle göre lokal olup, her iki yeni nokta da şeklin merkezinde, soldan 100 puan ve üstten 50 puan uzaklıktadır. 1 ve 4 numaralı segment indeksleri, bu noktaları üst ve alt kenarlara yerleştirerek bu kenarları içe doğru çeker.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Bir Şekilden Noktaları Kaldırın**

Bu örnek, bir kalp şeklindeki konturu, [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) metoduyla sıfır‑tabanlı 2. indeksteki segmenti kaldırarak değiştirir. Değiştirilmiş yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulamak şeklin konturunu günceller.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturun**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız inşa eder. 100 ve 50 puan dış ve iç yarıçapların dönüşümlü olarak kullanılması uçları ve girintileri tanımlar; 72 derece adım beş ucu eşit aralıklarla yerleştirir. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) ile kapatılır ve [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile bir dikdörtgen şeklinin konturunu değiştirir.

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Bileşik Özel Bir Şekil Oluşturun**

Bu örnek, bir şeklin üst ve alt üçte birlerini temsil eden iki kapalı [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) nesnesi tanımlar. İki yolu da [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulamak, ortası boyunca bir boşluk bırakan tek bir bileşik şekil oluşturur.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Yuvarlatılmış Köşeli Özel Bir Şekil Oluşturun**

Bu örnek, düz segmentleri [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ile birleştirerek içe doğru yuvarlatılmış köşelere sahip bir şekil üretir. Her köşe boyutu, yay genişliğini ve yüksekliğini puan olarak ayarlar; -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulanır ve sunum PPTX formatında kaydedilir.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenin**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) okur ve son segmentin [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) değerini [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) ile karşılaştırır. Boş olmayan yol olmadığında false döner. Bu kontrol, her yolun son komutunu inceler; yol içindeki her alt‑figürü incelemez. Örnek, bir dikdörtgen için `true` yazar.

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **Şekil Öğelerini Çıkarın ve İnceleyin**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) metodunu kullanarak bir şekli, yol noktaları ve nokta türleri içeren öğeler olarak inceleyin. Dönen her [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) öğesini [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) tipine dönüştürerek [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) ve [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) metodlarıyla nokta ve tür dizilerini alın. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için kullanışlıdır.

Örnek, input.pptx dosyasını açar, ilk slayttaki ilk geometri şekline doğrudan erişir ve yol segmentlerini yazdırır. Hem düz hem de eğri segmentlere sahip bir şekil içeren bir sunum kullanarak her iki çıktıyı da görebilirsiniz. Gruplar içinde arama yapılmaz.

```java
import com.aspose.slides.*;
import android.graphics.PointF;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Bölüm tipini tut, bayrakları dışarıda bırak.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Hem kontrol noktalarını hem de bitiş noktasını tüket.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Diziler indeks bazında eşleşir: `points[i]` bir noktayı, `types[i]` ise onun rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` önceki noktadan şimdiki noktaya bir çizgi çizer. Kübik Bézier segmenti, önceki bitiş noktasından başlar ve ardışık üç tip‑`3` girdisi kullanır: iki kontrol noktası ve yeni bitiş noktası. Döngü bu üç girişi birlikte tüketir ve kapanışı kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` ile maskeleyin, kapalı bir alt‑yolu tespit etmek için `0x80` bayrağını ayrı ayrı test edin. Örneğin `129` (`0x81`) bir satır bitiş noktasının aynı zamanda bir alt‑yolu kapattığını, `131` (`0x83`) ise bir Bézier bitiş noktasının kapattığını gösterir. Java bu bayrakları işaretli bayt olarak saklar; maskeleme gerçek bit değerlerini korur. Sadece `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) biriminde ölçülür; X sağa, Y aşağıya doğru artar. Gruplandırılmamış bir şekil için çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) ve [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) tarafından döndürülen konumu ve mevcut genişlik‑yüksekliği içerir. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` olur. Şeklin konumunu tekrar eklemeyin; X ve Y değerlerini çıkararak coordinates’ı döndürülmemiş çerçeveye göre göreceli hale getirin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) tarafından döndürülen şekil dönüşünü veya yatay‑dikey çevirileri içermez. Görüntülenen konturu yeniden oluşturmak için bu dönüşümleri şeklin merkezine göre uygulayın. Gruplandırılmış şekillerde ayrıca grup koordinat eşlemelerini ve dönüşümlerini hesaba katın; çıkarılan noktaların slayt üzerindeki nihai render koordinatları olduğunu varsaymayın ve çeviri ya da ölçeklendirmeyi iki kez uygulamayın.

**İnceleme ve düzenleme arasındaki fark.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz ya da çizim kodunuz nokta/tür dizilerine ihtiyaç duyduğunda bu yöntemi seçin. Şeklin yerel koordinat sisteminde geometri komutlarına ihtiyacınız varsa veya geometrisini düzenlemek istiyorsanız [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) veya [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulayın.

## **SSS**

**Geometriyi değiştirdikten sonra dolgu ve kontur ne olur?**

Stil şekil içinde kalır; yalnızca kontur değişir. Dolgu ve kontur otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli, geometrisiyle birlikte nasıl doğru şekilde döndürebilirim?**

Şeklin [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) metodunu kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğundan şekil ile birlikte döner.

**Özel bir şekli bir görüntüye dönüştürerek sonucu “kilitleyebilir” miyim?**

Evet. Gerekli [slayt](/slides/tr/androidjava/convert-powerpoint-to-png/) bölgesini ya da [şekil](/slides/tr/androidjava/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.