---
title: Java'da Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/java/custom-shape/
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
- eğimli köşe
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğimli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek Aspose.Slides içinde sunum şekillerini nasıl özelleştireceğinizi açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenmiş geometriyi bir şekle yeniden uygulamak için [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) ile nasıl çalışılacağını gösterir.  
Ayrıca özel ve birleşik şekillerin nasıl oluşturulacağını, eğimli köşeli şekillerin nasıl inşa edileceğini, bir şekil geometrisinin kapalı olup olmadığını nasıl belirleyeceğinizi, şekil öğelerini nasıl inceleyeceğinizi ve Java AWT metin hatlarını geometri yollarına nasıl dönüştüreceğinizi gösterir.

## **Edit Noktaları Kullanarak Bir Şekli Değiştirme**

PowerPoint'te, bir kareyi düzenlemek için **Edit Points** kullanabilirsiniz:

* Bir köşeyi içeriye veya dışarıya hareket ettirin.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Edit noktaları, bir şeklin dış hattını değiştirmenizi veya mevcut bir şekli yeni birinin temeli olarak kullanmanızı sağlar.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken, aşağıdaki kavramları aklınızda tutun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan tutama (anchor) noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Tutama noktaları ve kontrol tutamaçları şekline karar verir.
* Tutama noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Bir köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Bir yumuşak noktada, iki kontrol tutamaçı hizalanır ve tutama noktasından eşit mesafededir.
  * Bir düz noktada, iki kontrol tutamaçı hizalanır ancak tutama noktasına farklı mesafelerde olabilir.
* Tutama noktalarını hareket ettirmek veya tutamaçlarını ayarlamak şeklin dış hattını değiştirir.

PowerPoint şekillerini edit noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) sınıfını ve [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) arayüzünü sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) örneği, [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) nesnesinin geometri yolunu temsil eder.
* Bir [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) nesnesini [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) örneğinden almak için [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) metodunu kullanabilirsiniz.
* Bir şekle [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ayarlamak için tek bir yolu olan şekillerde [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) metodunu, birden çok yolu olan şekillerde ise [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) metodunu kullanabilirsiniz.
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) ve [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) yöntemleriyle bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) metodunu kullanarak bir [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) yolunu segment dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) nesnesini [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) aracılığıyla okuyup segmentleri bir [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) üzerine yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Bir geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir indeksi kabul eden aşırı yüklemeler, segmenti yolun segment dizisindeki sıfırdan başlayan konuma ekler.

| Operation | Method |
| --- | --- |
| Düz bir çizgi ekleyin veya ekleyin. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| İki kontrol noktası ve bir bitiş noktasına sahip bir kübik Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Bir kontrol noktası ve bir bitiş noktasına sahip bir ikinci dereceli Bézier eğrisi ekleyin veya ekleyin. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Belirtilen boyutlar ve derece cinsinden açılarla bir eliptik yay ekleyin. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Geçerli şekli, bitiş noktasını başlangıç noktasına bağlayarak kapatın. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Bir şeklin başlangıç noktasını ayarlayın. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Sıfırdan başlayan bir indeksdeki segmenti kaldırın. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Bir Şekle Özel Noktalar Ekleyin**

Bu örnek, bir dikdörtgen şekline [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) kullanarak iki nokta ekler ve düzenlenmiş yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygular. Koordinatlar şekle göre lokalizedir: iki yeni nokta da şeklin merkezinde, soldan 100 puan ve üstten 50 puan uzaklıktadır. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirerek bu kenarları içeri çeker.

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

Bu örnek, [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) ile sıfırdan başlayan indeks 2'deki segmenti kaldırarak kalp şekilli bir dış hatı değiştirir. Değiştirilen yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulayarak şeklin konturunu günceller.

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

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) kullanarak beş köşe yıldız oluşturur. 100 ve 50 puanlık dış ve iç yarıçapların dönüşümlü olarak kullanılması uçları ve girintileri tanımlar; 72 derece adım beş ucu eşit şekilde aralar. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) ile kapatılır ve [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile bir dikdörtgen şekle uygulanarak dış hatı değiştirir.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
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

## **Bileşik Özel Bir Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte birleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulayarak ortasında bir boşluk bulunan tek bir bileşik şekil oluşturur.

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

## **Eğimli Köşeli Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ile düz segmentleri birleştirerek içe doğru eğimli köşelere sahip bir şekil oluşturur. Her köşe boyutu, yayının genişliğini ve yüksekliğini puan cinsinden ayarlar ve -90 derece süpürme, saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulanır ve sunum PPTX biçiminde kaydedilir.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

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

İşte aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) okur ve son segmentin [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) değerini [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) ile karşılaştırır. Boş yol olmadığında false döndürür. Bu, her yolun son komutunu inceler; yol içindeki her alt şekli incelemez. Örnek, bir dikdörtgen için `true` yazdırır.

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

[contour.pptx](contour.pptx) dosyasını indirip uygulamanın çalışma dizinine koyun. İlk slayttaki ilk şeklin düz bir üst kenarı, bir kübik Bézier eğrisi ve düz bir kapanış kenarı vardır. Şeklin yollarını okumak için [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) ve her yolun segmentlerini çizim sırasına göre okumak için [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) kullanın. Her segment için, [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) komutu tanımlar ve [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) tarafından döndürülen değerlerin nasıl yorumlanacağını belirler.

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

Şekil slaytta (200, 100) puanda konumlanır. Bildirilen koordinatlar şekle göre yereldir; (0, 0) sol üst köşesinde, x sağa, y aşağıya doğru artar. Kapanış segmenti ek koordinat olmadan başlangıç noktasına geri döner.

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![Üst kenarı düz, sağ üstten sol alta eğimli bir kenarı ve sol kenarı düz olan PowerPoint şekli](contour.png)

## **Şekil Öğelerini Çıkarma ve İnceleme**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) kullanarak mevcut bir şekli yol noktaları ve nokta tiplerini içeren öğeler olarak inceleyin. Döndürülen her [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) öğesini [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) tipine dönüştürerek [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) ve [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) yöntemleriyle nokta ve tip dizilerini alın. Bu temsil, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için kullanışlıdır.

Örnek, input.pptx dosyasını açar, doğrudan ilk slayttaki ilk geometri şekli bulur ve yol segmentlerini yazdırır. Hem düz hem de eğimli segmentlere sahip bir şekil içeren bir sunum kullanarak her iki çıktıyı da görebilirsiniz. Grupların içinde arama yapmaz.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // Segment türünü tut, bayrakları dışarıda bırak.
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

Diziler indeksle eşleşir: `points[i]` bir noktadır ve `types[i]` rolünü açıklar. Tip `0` bir şekli başlatır, tip `1` önceki noktadan mevcut noktaya bir çizgi çizer. Bir kübik Bézier segmenti önceki bitiş noktasından başlar ve ardışık üç tip-`3` girdisi kullanır: iki kontrol noktası ve ardından yeni bitiş noktası. Döngü bu üç girdiyi birlikte tüketir ve bitiş noktasının kapanışını kontrol eder.

Nokta tipleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi, kapalı alt yolu tespit etmek için ise `0x80` ayrı ayrı test edilmelidir. Örneğin, `129` (`0x81`) bir alt yolu kapatan çizgi bitiş noktasını, `131` (`0x83`) ise bir alt yolu kapatan Bézier bitiş noktasını ifade eder. Java bu bayrakları imzalı baytlar olarak saklar; maskeleme amaçlanan bit değerlerini korur. Ham değeri sadece `1` veya `3` ile karşılaştırmak bu durumları kaçırır. Çizgi (`0x10`) ve işaretçi (`0x20`) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar, inçin 1/72'si olan puan cinsinden ölçülür; X sağa, Y aşağıya doğru artar. Gruplanmamış bir şekil için, çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) ve [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) tarafından döndürülen konumu içerir ve mevcut genişlik ve yüksekliğini yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu tekrar eklemeyin. X ve Y'sini çıkararak koordinatları döndürülmemiş çerçeveye göre elde edin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) tarafından döndürülen şeklin dönüşünü veya yatay ve dikey çevirileri içermez. Görüntülenen konturu yeniden oluşturmak için bu dönüşümleri şeklin merkezine göre uygulayın. Gruplu şekiller için, grup koordinat haritalamasını ve dönüşümleri de dikkate alın; çıkarılan noktaların son render edilmiş slayt koordinatları olduğunu varsaymayın ve çocuğun çerçevesinde zaten yansıtılmışsa bir çeviri veya ölçeklendirmeyi iki kez uygulamayın.

**İnceleme ve düzenleme karşılaştırması.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analizinizin veya çizim kodunuzun nokta/tip dizilerine ihtiyacı olduğunda bu yöntemi seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyacınız olduğunda veya geometrisini düzenlemek istediğinizde [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) veya [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) aracılığıyla uygulayın.

## **Java AWT Şeklini GeometryPath'e Dönüştürme**

Bu örnek, geometriye dönüştürülmüş bir metinle dikdörtgen bir dış hatı birleştirir. Dış hattın [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) metodu doldurmasını devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin dış hattını oluşturur. [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceli, kübik ve kapanış segmentleri sağlar; örnek bu segmentleri bir [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) üzerinde tekrar oynatır.

Metin, 40 puanlık Arial yazı tipini kullanır. Dış hat yatayda 20 puan kaydırılır ve görsel üst kısmı şeklin üst kenarının 10 puan altında konumlandırılır. Metin yolu doldurulur, orijinal dikdörtgen ise sadece dış hat olarak kalır. Her iki yolu da [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulayarak dikdörtgen ve metni içeren tek bir şekil oluşturur.

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // Yeni şekil oluştur
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Şeklin geometri yolunu al
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Metin ile yeni grafik yolu oluştur
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // Grafik yolunu geometri yoluna dönüştür
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // Şekle yeni geometri yolu ve orijinal geometri yolunun kombinasyonunu ayarla
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometriyi değiştirdikten sonra doldurma ve dış hat ne olur?**  
Stil şekilde kalır; yalnızca kontur değişir. Doldurma ve dış hat yeni geometriye otomatik olarak uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru bir şekilde döndürebilirim?**  
Şeklin [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) metodunu kullanın; geometri şekille birlikte döner çünkü şeklin kendi koordinat sistemine bağlanmıştır.

**Özel bir şekli sonucu "kilitlemek" için bir görüntüye dönüştürebilir miyim?**  
Evet. Gerekli [slayt](/slides/tr/java/convert-powerpoint-to-png/) alanını veya [şekil](/slides/tr/java/create-shape-thumbnails/) kendisini bir raster formatına dışa aktarın; bu, karmaşık geometrilerle sonraki çalışmayı basitleştirir.