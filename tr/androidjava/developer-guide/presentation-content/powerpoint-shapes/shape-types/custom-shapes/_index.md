---
title: Android'de Sunum Şekillerini Özelleştirme
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
- düzenleme noktaları
- nokta ekle
- nokta kaldır
- düzenleme işlemi
- eğimli köşe
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android Java aracılığıyla PowerPoint sunumlarında şekilleri oluşturun ve özelleştirin: geometri yolları, eğimli köşeler, bileşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek özelleştirmenin nasıl yapılacağını açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenmiş geometriyi bir şekle uygulamak için [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca, özel ve bileşik şekiller oluşturmayı, eğimli köşeli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi ve Android nokta dizileri kullanarak şekil öğelerini incelemeyi de gösterir.

## **Düzenleme Noktaları Kullanarak Şekil Değiştirme**

PowerPoint'te bir kareyi değiştirmek için **Düzenleme Noktaları** kullanabilirsiniz:

* Bir köşeyi içeriye ya da dışarıya taşıyın.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin dış hattını değiştirmek veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmak için izin verir.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda bulundurun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan ankraj (çapa) noktalarından oluşur.
* Bir segment düz veya eğrisel olabilir. Ankraj noktaları ve kontrol tutamaçları şeklin şeklini belirler.
* Ankraj noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Bir köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Bir yumuşak noktada, iki kontrol tutamaçı hizalanır ve ankraj noktasına eşit uzaklıktadır.
  * Bir düz noktada, iki kontrol tutamaçı hizalanır ancak ankraj noktasına farklı mesafelerde olabilir.
* Ankraj noktalarını hareket ettirmek veya tutamaçlarını ayarlamak şeklin dış hattını değiştirir.

Düzenleme noktalarıyla PowerPoint şekillerini düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) sınıfını ve [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) arayüzünü sunar.

* [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) bir örnek, [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) nesnesinin geometri yolunu temsil eder.
* [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) almak için [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) metodunu kullanabilirsiniz.
* Bir şekle [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) ayarlamak için şu yöntemleri kullanabilirsiniz: tek bir yolu olan şekiller için [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ve birden çok yolu olan şekiller için [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---).
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) ve [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) yöntemlerini kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) metodunu kullanarak bir [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) geometrisinin yolunu yol segmentleri dizisi olarak alabilirsiniz.

## **Basit Düzenleme İşlemleri**

Geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir dizin kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki o sıfır‑tabanlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekle veya ekleyin. | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| İki kontrol noktası ve bir son nokta ile kübik Bézier eğrisi ekle veya ekleyin. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Bir kontrol noktası ve bir son nokta ile ikinci dereceden Bézier eğrisi ekle veya ekleyin. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Belirtilen boyut ve derecelerde açılarla eliptik bir yay ekle. | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Geçerli figürü, son noktasını başlangıç noktasına bağlayarak kapat. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| Bir figürün başlangıç noktasını ayarla. | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Sıfır‑tabanlı bir dizinde bir segmenti kaldır. | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Bir Şekle Özel Noktalar Ekle**

Bu örnek, [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) kullanarak bir dikdörtgen şekline iki nokta ekler ve düzenlenmiş yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygular. Koordinatlar şekle göre lokaldir: her iki yeni nokta da merkezde, soldan 100 puan ve üstten 50 puan uzaktadır. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirir ve bu kenarları içeri çeker.

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

## **Bir Şekilden Noktalar Kaldırma**

Bu örnek, [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) kullanarak sıfır‑tabanlı 2. indeksteki segmenti kaldırarak kalp şeklindeki dış hattı değiştirir. Değiştirilen yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulamak şeklin konturunu günceller.

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

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. Dış ve iç yarıçapların (100 ve 50 puan) dönüşümlü olarak kullanılması uç noktaları ve girintileri tanımlar; 72 derece adım beş ucu eşit aralıklarla yerleştirir. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) ile kapatılır ve bir dikdörtgen şekle [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulanarak dış hattı değiştirilir.

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

## **Bileşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte bir bölümleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulamak, ortasında bir boşluk bulunan tek bir bileşik şekil oluşturur.

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

## **Eğimli Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ile birleştirerek içe doğru eğimli köşelere sahip bir şekil oluşturur. Her köşe boyutu, yay genişliğini ve yüksekliğini puan cinsinden ayarlar ve -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulanır ve sunum PPTX formatında kaydedilir.

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

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapama segmentiyle bitip bitmediğini kontrol eder. [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) okuyarak son segmentin [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) değerini [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) ile karşılaştırır. Boş yol olmadığında false döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki tüm alt şekilleri incelemez. Örnek, bir dikdörtgen için `true` yazdırır.

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

## **Geometri Yol Komutlarını İnceleme**

[contour.pptx](contour.pptx) dosyasını indirin ve örnek dosya adını cihazınızdaki yol ile değiştirin. İlk slaydın ilk şekli, düz bir üst kenar, kübik Bézier eğrisi ve düz bir kapanış kenarına sahiptir. Şeklin yollarını okumak için [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) ve her yolun segmentlerini çizim sırasına göre okumak için [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) kullanın. Her segment için, [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) komutu tanımlar ve [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) tarafından döndürülen değerlerin nasıl yorumlanacağını belirler.

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

Şekil, slaytta (200, 100) puan konumunda bulunur. Bildirilen koordinatlar şekle göre lokaldir; (0, 0) sol‑üst köşesindedir, x sağa doğru artar ve y aşağı doğru artar. Kapanış segmenti ek koordinat olmadan başlangıç noktasına döner.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Şekil Öğelerini Çıkarma ve İnceleme**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) yöntemini kullanarak mevcut bir şekli, yol noktaları ve nokta türlerini içeren öğeler olarak inceleyin. Döndürülen her [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) öğesini [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) tipine dönüştürerek [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) ve [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) metodlarıyla nokta ve tür dizilerini alın. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için faydalıdır.

Örnek, input.pptx dosyasını açar, ilk slaytta doğrudan ilk geometri şeklini bulur ve yol segmentlerini yazdırır. Hem düz hem de eğimli segmentlere sahip bir şekil içeren bir sunum kullanarak her iki çıktıyı da görebilirsiniz. Gruplar içinde arama yapmaz.

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
                int pointType = types[i] & 0x07; // Segment tipini tut, bayraklar hariç.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
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

Diziler indeks bazında eşleşir: `points[i]` bir noktadır ve `types[i]` onun rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` önceki noktadan mevcut noktaya bir çizgi çizer. Kübik Bézier segmenti, önceki son noktadan başlar ve üç ardışık tip-`3` girdisini kullanır: iki kontrol noktası ve ardından yeni son nokta. Döngü bu üç girişi birlikte tüketir ve kapanış için son noktayı kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi, kapalı alt yol tespiti için ise `0x80` ayrı ayrı test edilir. Örneğin, `129` (`0x81`) bir alt yolu kapatan çizgi son noktası, `131` (`0x83`) ise bir alt yolu kapatan Bézier son noktası demektir. Java bu bayrakları işaretli byte olarak saklar; maskeler orijinal bit değerlerini korur. Ham değeri yalnızca `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Tire (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar, inçin 1/72'si olan puan cinsinden ölçülür; X sağa, Y aşağıya doğru artar. Gruplanmamış bir şekil için, çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) ve [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliğini yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin. X ve Y değerlerini çıkararak döndürülmemiş çerçeveye göre koordinatları elde edin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) tarafından döndürülen şekil dönüşünü veya yatay ve dikey çevirileri uygulamaz. Görünen konturu yeniden oluşturmak için bu dönüşümleri şeklin merkezinde uygulayın. Gruplandırılmış şekiller için grup koordinat haritalamasını ve dönüşümleri de hesaba katın; çıkarılan noktaların nihai slayt koordinatları olduğunu varsaymayın ve çocuğun çerçevesinde zaten yansıtılmış bir çevirme veya ölçekleme varsa bunu iki kez uygulamayın.

**İnceleme ve düzenleme karşılaştırması.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analizinizin veya çizim kodunuzun nokta/tür dizilerine ihtiyacı olduğunda bu yöntemi seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyacınız varsa veya geometrisini düzenlemek istiyorsanız [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) veya [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulayın.

## **SSS**

**Geometri değiştirildikten sonra dolgu ve dış hat ne olur?**  
Stil şekil ile birlikte kalır; sadece kontur değişir. Dolgu ve dış hat otomatik olarak yeni geometriye uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru bir şekilde döndürürüm?**  
Şeklin [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) metodunu kullanın; geometri, şeklin kendi koordinat sistemine bağlı olduğu için şekil ile birlikte döner.

**Sonucu "kilitlemek" için özel bir şekli görüntüye dönüştürebilir miyim?**  
Evet. Gerekli [slide](/slides/tr/androidjava/convert-powerpoint-to-png/) alanını veya [shape](/slides/tr/androidjava/create-shape-thumbnails/) öğesini raster bir formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı kolaylaştırır.