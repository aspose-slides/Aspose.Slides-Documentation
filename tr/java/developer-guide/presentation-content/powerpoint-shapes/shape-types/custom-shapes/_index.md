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
- şekli değiştir
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğimli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek özelleştirmenin nasıl yapılacağını açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemlerini gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenmiş geometrinin bir şekle uygulanmasını göstermek için [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ve [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) ile nasıl çalışılacağını gösterir.

Ayrıca, özel ve birleşik şekiller oluşturmayı, köşeleri eğimli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi, şekil öğelerini incelemeyi ve Java AWT metin konturlarını geometri yollarına dönüştürmeyi gösterir.

## **Düzenleme Noktalarıyla Bir Şekli Değiştirmek**

PowerPoint'te **Edit Points** (Düzenleme Noktaları) kullanarak bir kareyi değiştirebilirsiniz:

* Köşeyi içe veya dışa doğru taşıyın.
* Bir noktadaki eğriliği ayarlayın.
* Yeni noktalar ekleyin.

Düzenleme noktaları, bir şeklin dış hattını değiştirmenizi veya mevcut bir şekli yeni bir şeklin temeli olarak kullanmanızı sağlar.

## **Şekil Düzenleme İpuçları**

![genel_resim](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları akılda tutun:

* Bir şekil (veya yolu) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanan çapa noktalarından oluşur.
* Bir segment düz veya eğri olabilir. Çapa noktaları ve kontrol tutamaçları şeklinin şeklini belirler.
* Çapa noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Bir köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Bir yumuşak noktada, iki kontrol tutamaçı hizalıdır ve çapa noktasına eşit mesafededir.
  * Bir düz noktada, iki kontrol tutamaçı hizalıdır ancak çapa noktasına farklı mesafelerde olabilir.
* Çapa noktalarını taşımak veya tutamaçlarını ayarlamak şeklin dış hattını değiştirir.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) sınıfı ve [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) arayüzünü sağlar.

* Bir [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) örneği, [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) nesnesinin bir geometri yolunu temsil eder.
* [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) metodunu kullanarak [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) alabilirsiniz.
* Bir şekle [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ayarlamak için tek yollu şekiller için [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) metodunu ve çoklu yollu şekiller için [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) metodunu kullanabilirsiniz.
* Segment eklemek için [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) altındaki metodları kullanabilirsiniz.
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) ve [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) metodlarını kullanarak bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) metodunu kullanarak bir [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) geometrisini yol segmentleri dizisi olarak alabilirsiniz.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) öğesini [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) aracılığıyla okuyup segmentleri bir [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) üzerine yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Geometri yolunu düzenlemek için aşağıdaki yöntemleri kullanın. Bir dizin kabul eden aşırı yüklemeler, segmenti yolun sıfır tabanlı konumuna ekler.

| İşlem | Metot |
| --- | --- |
| Düz bir çizgi ekle veya ekle. | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| İki kontrol noktası ve bir uç nokta ile kübik Bézier eğrisi ekle veya ekle. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| Bir kontrol noktası ve bir uç nokta ile ikinci dereceden Bézier eğrisi ekle veya ekle. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| Belirtilen boyut ve derece cinsinden açıyla eliptik bir yay ekle. | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| Şeklin uç noktasını başlangıç noktasına bağlayarak mevcut figürü kapat. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| Bir figürün başlangıç noktasını ayarla. | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| Sıfır tabanlı bir indekste bir segmenti kaldır. | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **Bir Şekle Özel Noktalar Eklemek**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) kullanır ve düzenlenmiş yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygular. Koordinatlar şekle göre lokaldir: iki yeni nokta da şeklin merkezindedir, sol kenardan 100 puan ve üstten 50 puan uzakta. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirir ve bu kenarları içe doğru çeker.

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

![örnek1_resim](custom_shape_1.png)

## **Bir Şekilden Noktaları Kaldırmak**

Bu örnek, [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) ile sıfır tabanlı 2 indeksteki segmenti kaldırarak kalp şekilli bir dış hattı değiştirir. Değiştirilmiş yolu [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulamak şeklin konturunu günceller.

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
![örnek2_resim](custom_shape_2.png)

## **Özel Bir Şekil Oluşturmak**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız oluşturur. Dış ve iç yarıçapların 100 ve 50 puan dönüşümlü olması uçları ve girintileri tanımlar; 72 derece adım beş ucu eşit olarak aralar. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) ile kapatılır ve [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile bir dikdörtgen şekline uygulanarak dış hattı değiştirilir.

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
![örnek3_resim](custom_shape_3.png)

## **Bileşik Özel Bir Şekil Oluşturmak**

Bu örnek, bir şeklin üst ve alt üçte birleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) nesnesi tanımlar. Her iki yolu da [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulamak, orta üçte birinde bir boşluk olan tek bir bileşik şekil oluşturur.

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
![örnek4_resim](custom_shape_4.png)

## **Eğimli Köşeli Özel Bir Şekil Oluşturmak**

Bu örnek, düz segmentleri [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) ile birleştirerek içe doğru eğimli köşelere sahip bir şekil oluşturur. Her köşe boyutu, yay genişliğini ve yüksekliğini puan cinsinden ayarlar ve -90 derece süpürme saat yönünün tersine bir çeyrek elips çizer. Tamamlanan yol, [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) ile uygulanır ve sunum PPTX formatında kaydedilir.

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

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenmek**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun kapanış segmentiyle bitip bitmediğini kontrol eder. [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) okunur ve son segmentin [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) değeri [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) ile karşılaştırılır. Boş olmayan yol yoksa false döner. Bu, her yolun son komutunu kontrol eder; bir yol içindeki her alt şekli incelemez. Örnek bir dikdörtgen için `true` yazdırır.

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

## **Şekil Öğelerini Çıkarmak ve İncelemek**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) kullanarak mevcut bir şekli yol noktaları ve nokta türleri içeren öğeler olarak inceleyin. Döndürülen her [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/)’e dönüştürülerek [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) ve [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) metodlarıyla nokta ve tip dizileri alınır. Bu temsili, kontur analizi veya geometrinin özel çizim araçlarına aktarılması için yararlıdır.

Örnek, input.pptx dosyasını açar, ilk slayttaki ilk geometri şeklini bulur ve yol segmentlerini yazdırır. Hem düz hem de eğri segmentler içeren bir şekil içeren bir sunum kullanın; grupların içine arama yapmaz.

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
                int pointType = types[i] & 0x07; // Segment tipini tut, bayrakları hariç.
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

Array'ler indeks bazında eşleşir: `points[i]` bir noktadır ve `types[i]` rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` bir önceki noktadan şimdiki noktaya bir çizgi çizer. Bir kübik Bézier segmenti önceki uç noktadan başlar ve ardışık üç `type-3` girdisi kullanır: iki kontrol noktası ve yeni uç nokta. Döngü bu üç girişi birlikte tüketir ve kapanış için uç noktayı kontrol eder.

Nokta türleri ayrıca bayraklar içerir. Segment tipini belirlemek için `0x07` maskesi uygulanır, kapalı bir alt yolu tespit etmek için `0x80` ayrı ayrı test edilir. Örneğin, `129` (`0x81`) bir alt yolu kapatan çizgi uç noktası, `131` (`0x83`) ise bir Bézier uç noktasının kapatıldığı anlamına gelir. Java bu bayrakları imzalı baytlar olarak saklar; maskeleme amaçlanan bit değerlerini korur. Yalnızca `1` veya `3` ile ham değeri karşılaştırmak bu durumları kaçırır. Diğer bayraklar, örneğin tire (`0x10`) ve işaretçi (`0x20`), temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan cinsindendir (inç'in 1/72'i), X sağa, Y aşağı doğru artar. Gruplanmamış bir şekil için çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) ve [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) tarafından döndürülen pozisyonu içerir ve mevcut genişlik ve yüksekliği yansıtır. Örneğin, `(100, 200)` konumunda ve `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)`'dir. Şeklin konumunu tekrar eklemeyin. X ve Y'yi çıkararak koordinatları döndürülmemiş çerçeveye göre alın.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) tarafından döndürülen şekil dönüşünü veya yatay ve dikey çevirileri içermez. Görünen konturu yeniden üretmek için bu dönüşümleri şeklin merkezinde uygulayın. Gruplu şekiller için grup koordinat haritalaması ve dönüşümlerini de hesaba katın; çıkarılan noktaların nihai slayt koordinatları olduğunu varsaymayın ve çocuğun çerçevesinde zaten yansıtılmışsa bir çevirme veya ölçekleme iki kez uygulanmasın.

**İnceleme vs. düzenleme.** Çıkarılan dizi konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz veya çizim kodunuz nokta/tip dizilerine ihtiyaç duyduğunda bu yaklaşımı seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyacınız varsa veya geometrisini düzenlemek istiyorsanız [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) veya [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulayın.

## **Java AWT Şeklini GeometryPath'e Dönüştürmek**

Bu örnek, bir dikdörtgen konturunu metinle birleştirerek geometriye dönüştürür. Konturun [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) yöntemi doldurmasını devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin konturunu yaratır. Bunun [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceden, kübik ve kapanış segmentlerini sağlar; örnek bunları bir [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) üzerinde tekrar oynatır.

Metin 40 puanlık Arial yazı tipini kullanır. Kontur, yatayda 20 puan kaydırılır ve görsel üstü şeklin üst kenarının 10 puan altında konumlandırılır. Metin yolu doldurulur, orijinal dikdörtgen ise sadece bir kontur kalır. Her iki yolu da [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) ile uygulamak, dikdörtgen ve metni içeren tek bir şekil üretir.

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

    // Metinle yeni grafik yolu oluştur
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
![örnek5_resim](custom_shape_5.png)

## **SSS**

**Geometriyi değiştirdikten sonra doldurma ve dış hat ne olur?**

Stil şekil ile kalır; sadece kontur değişir. Doldurma ve dış hat yeni geometriye otomatik olarak uygulanır.

**Özel bir şekli geometrisiyle birlikte nasıl doğru bir şekilde döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) metodunu kullanın; geometri şekille birlikte döner çünkü şeklin kendi koordinat sistemine bağlıdır.

**Sonucu "kilitlemek" için özel bir şekli görüntüye dönüştürebilir miyim?**

Evet. Gerekli [slaytı](/slides/tr/java/convert-powerpoint-to-png/) alanını veya [şekli](/slides/tr/java/create-shape-thumbnails/) kendisini raster bir formata dışa aktarın; bu, karmaşık geometrilerle daha sonraki çalışmayı basitleştirir.