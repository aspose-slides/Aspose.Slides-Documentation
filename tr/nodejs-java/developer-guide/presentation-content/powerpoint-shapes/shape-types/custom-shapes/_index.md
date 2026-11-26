---
title: JavaScript ile Sunum Şekillerini Özelleştirme
linktitle: Özel Şekil
type: docs
weight: 20
url: /tr/nodejs-java/custom-shape/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js ile PowerPoint sunumlarında şekiller oluşturun ve özelleştirin: geometri yolları, eğimli köşeler, birleşik şekiller."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde sunum şekillerini düzenleme noktaları ve geometri yolları aracılığıyla şekil geometrisini düzenleyerek nasıl özelleştirileceğini açıklar. Mevcut şekilleri değiştirmek, temel yol düzenleme işlemleri gerçekleştirmek, nokta eklemek veya kaldırmak ve güncellenen geometriyi bir şekle geri uygulamak için [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) kullanımını gösterir.

Ayrıca özel ve birleşik şekiller oluşturmayı, köşeleri eğimli şekiller inşa etmeyi, bir şekil geometrisinin kapalı olup olmadığını belirlemeyi, şekil öğelerini incelemeyi ve Java AWT metin konturlarını geometri yollarına dönüştürmeyi de örnekler.

## **Düzenleme Noktalarını Kullanarak Bir Şekli Değiştirme**

PowerPoint’te **Düzenleme Noktaları**nı bir kareyi değiştirmek için kullanabilirsiniz:

* Bir köşeyi içe ya da dışa doğru taşıma.
* Bir noktadaki eğriliği ayarlama.
* Yeni noktalar ekleme.

Düzenleme noktaları, bir şeklin ana hatlarını değiştirmenize ya da mevcut bir şekli yeni bir şeklin temeli olarak kullanmanıza olanak tanır.

## **Şekil Düzenleme İpuçları**

![overview_image](custom_shape_0.png)

PowerPoint şekillerini düzenlerken şu kavramları aklınızda tutun:

* Bir şeklin (veya yolunun) kapalı ya da açık olabilir.
* Bir şeklin yolu, segmentlerle bağlanmış demirleme (anchor) noktalarından oluşur.
* Bir segment düz ya da eğimli olabilir. Demirleme noktaları ve kontrol sapları şeklin biçimini belirler.
* Demirleme noktaları köşe noktaları, düz noktalar veya yumuşak noktalar olarak bulunur:
  * Köşe noktasında, bitişik segmentler bir açıyla buluşabilir.
  * Yumuşak noktada iki kontrol sapı hizalıdır ve demirleme noktasından eşit uzaklıktadır.
  * Düz noktada iki kontrol sapı hizalıdır ancak demirleme noktasından farklı uzaklıklarda bulunabilir.
* Demirleme noktalarını taşıyarak ya da saplarını ayarlayarak şeklin ana hattını değiştirirsiniz.

PowerPoint şekillerini düzenleme noktalarıyla düzenlemek için **Aspose.Slides**, [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) sınıfını sunar.

* Bir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) örneği, [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) nesnesinin geometri yolunu temsil eder.
* [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) yöntemini kullanarak bir [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) örneğinden [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) alabilirsiniz.
* Bir şekil için [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ayarlamak istediğinizde, tek bir yola sahip şekiller için [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath), birden fazla yola sahip şekiller için ise [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) yöntemlerini kullanın.
* Segment eklemek için [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) altındaki yöntemleri kullanabilirsiniz.
* [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) ve [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) yöntemleriyle bir geometri yolunun görünümünü ayarlayabilirsiniz.
* [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) yöntemi, bir [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) geometrisini yol segmentleri dizisi olarak almanızı sağlar.
* Ek şekil geometri özelleştirme seçeneklerine erişmek için bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html)’i [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) üzerinden okuyup segmentleri bir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) üzerine yeniden oynatabilirsiniz.

## **Basit Düzenleme İşlemleri**

Aşağıdaki yöntemleri kullanarak bir geometri yolunu düzenleyin. İndeks kabul eden aşırı yüklü sürümler, segmenti yolun segment dizisindeki sıfır‑bazlı konuma ekler.

| İşlem | Yöntem |
| --- | --- |
| Düz bir çizgi ekle veya ekle. | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| İki kontrol noktası ve bir bitiş noktası içeren kübik Bézier eğrisi ekle veya ekle. | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| Tek bir kontrol noktası ve bir bitiş noktası içeren ikinci dereceden Bézier eğrisi ekle veya ekle. | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| Belirtilen boyut ve derecedeki açıyla eliptik bir yay ekle. | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| Bitiş noktasını başlangıç noktasına bağlayarak geçerli figürü kapat. | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| Bir figürün başlangıç noktasını ayarla. | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| Sıfır‑bazlı bir indeksteki segmenti kaldır. | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **Şekle Özel Noktalar Ekleme**

Bu örnek, bir dikdörtgen şekline iki nokta eklemek için [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) kullanır ve düzenlenmiş yolu [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ile uygular. Koordinatlar şekle göre yereldir: yeni noktalar şeklin ortasında, soldan 100 puan, üstten 50 puan uzakta bulunur. Segment indeksleri 1 ve 4, bu noktaları üst ve alt kenarlara yerleştirerek kenarları içe doğru çeker.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **Şekilden Noktalar Kaldırma**

Bu örnek, bir kalp şeklinin ana hatını sıfır‑bazlı indeks 2’deki segmenti [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) ile kaldırarak değiştirir. Değiştirilen yolu [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulamak, şeklin konturunu günceller.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **Özel Bir Şekil Oluşturma**

Bu örnek, [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) kullanarak beş köşeli bir yıldız inşa eder. 100 puan dış yarıçap ve 50 puan iç yarıçap, uçları ve girintileri tanımlar; 72 derecelik adım beş ucu eşit aralıklı yerleştirir. Yol, [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) ile kapatılır ve bir dikdörtgen şekle [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) uygulanarak mevcut ana hat yerine konur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **Birleşik Özel Şekil Oluşturma**

Bu örnek, bir şeklin üst ve alt üçte bir bölümleri için iki kapalı [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) tanımlar. Her iki yol da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulanarak ortasındaki bir boşlukla tek bir birleşik şekil oluşturulur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **Eğimli Köşeli Özel Şekil Oluşturma**

Bu örnek, düz segmentleri [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) ile birleştirerek içe doğru eğimli köşelere sahip bir şekil üretir. Her köşe boyutu, yay genişliği ve yüksekliğini puan cinsinden ayarlar; –90 derecelik süpürme çeyrek bir elipsi saat yönünün tersine çizer. Tamamlanan yol, [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ile uygulanır ve sunum PPTX biçiminde kaydedilir.

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bir Şekil Geometrisinin Kapalı Olup Olmadığını Öğrenme**

Aşağıdaki yardımcı, her boş olmayan geometri yolunun bir kapanış segmentiyle bitip bitmediğini denetler. [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) okunur ve son segmentin [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) değeri [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) ile karşılaştırılır. Boş olmayan yol yoksa false döner. Bu, her yolun son komutunu kontrol eder; yol içindeki her alt‑figürü incelemez. Örnek, bir dikdörtgen için `true` yazdırır.

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **Geometri Yol Komutlarını İnceleme**

[contour.pptx](contour.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slayttaki ilk şekil, düz bir üst kenar, bir kübik Bézier eğrisi ve düz bir kapanış kenarı içerir. Şeklin yollarını okumak için [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths), her yolun segmentlerini çizim sırasına göre okumak için ise [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) kullanın. Her segment için [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) komutu tanımlar ve [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData) tarafından döndürülen değerlerin nasıl yorumlanacağını belirler.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

Şekil slayt üzerinde (200, 100) puan konumunda durur. Raporlanan koordinatlar şekle göre yereldir; (0, 0) şeklin sol‑üst köşesindedir, x sağa, y aşağı doğru artar. Kapanış segmenti ek koordinat olmadan başlangıç noktasına döner.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Şekil Elemanlarını Çıkarma ve İnceleme**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) kullanarak mevcut bir şekli yol noktaları ve nokta tipleri içeren elemanlar olarak inceleyin. Dönen her [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) için [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) ve [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) yöntemleriyle nokta ve tip dizileri alınır. Bu temsil, kontur analizi veya geometriyi özel çizim araçlarına aktarmak için yararlıdır.

Örnek, input.pptx dosyasını açar, ilk slayttaki ilk geometri şekline ulaşır ve yol segmentlerini yazdırır. Düz ve eğimli segmentler içeren bir şekil kullandığınızda her iki tür çıktıyı da görebilirsiniz. Gruplar içinde arama yapmaz.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Segment türünü tut, bayrakları hariç.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Hem kontrol noktalarını hem de uç noktasını tüket.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Diziler indeks bazında eşleşir: `points[i]` bir noktayı, `types[i]` ise onun rolünü tanımlar. Tip `0` bir figürü başlatır, tip `1` bir önceki noktadan mevcut noktaya doğru bir çizgi çizer. Kübik Bézier segmenti önceki bitiş noktasından başlar ve üç ardışık tip‑`3` girdisi kullanır: iki kontrol noktası ve yeni bitiş noktası. Döngü bu üç girişi birlikte tüketir ve bitiş noktasının kapanış olup olmadığını denetler.

Nokta tipleri ayrıca bayraklar taşır. Segment tipini tanımlamak için `0x07` maskesini, kapalı alt‑yolu tespit etmek için `0x80` bayrağını ayrı ayrı test edin. Örneğin `129` (`0x81`) bir çizgi bitiş noktasının aynı zamanda bir alt‑yolu kapattığını, `131` (`0x83`) ise bir Bézier bitiş noktasının kapattığını gösterir. Java bu bayrakları işaretli bayt olarak saklar; maskeleme orijinal bit değerlerini korur. Yalnızca `1` ya da `3` ile karşılaştırmak bu durumları kaçırır. `0x10` (çizgi) ve `0x20` (işaretleyici) gibi diğer bayraklar temel segment tipini değiştirmez.

**Koordinatlar ve dönüşümler.** Noktalar puan (1/72 inç) cinsindendir; X sağa, Y aşağı doğru artar. Gruplanmamış bir şekil için çıkarılan koordinatlar zaten [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) ve [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) tarafından döndürülen konumu içerir ve şeklin mevcut genişlik‑yüksekliğini yansıtır. Örneğin, `(100, 200)` konumunda, `120 × 80` boyutunda döndürülmemiş bir dikdörtgenin kontur sınırları `(100, 200)`–`(220, 280)` şeklindedir. Şeklin konumunu bir kez daha eklemeyin; X ve Y’yi çıkararak dönmeyen çerçeveye göre koordinatları elde edin.

Çıkarılan noktalar, [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) tarafından döndürülen şekil dönüşünü ya da yatay/vertikal yansımaları içermez. Görüntülenen konturu yeniden üretmek için bu dönüşümleri şeklin merkezine göre uygulayın. Gruplanmış şekillerde ayrıca grup koordinat haritalamasını ve dönüşümlerini hesaba katın; çıkarılan noktaların sunumda son render koordinatları olduğunu varsaymayın ve çeviri ya da ölçekleme işlemini iki kez uygulamayın.

**İnceleme vs. düzenleme.** Çıkarılan diziler konturu tanımlar; bunları değiştirmek orijinal şekli güncellemez. Analiz ya da çizim kodunuz nokta/tip dizilerine ihtiyaç duyduğunda bu yöntemi seçin. Şeklin yerel koordinat sistemindeki geometri komutlarına ihtiyaç duyarsanız ya da geometrisini düzenlemek isterseniz [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) kullanın. Düzenlenmiş yolları [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) ya da [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulayın.

## **Java AWT Shape’ını GeometryPath’e Dönüştürme**

Bu örnek, bir dikdörtgen konturunu metinle birleştirerek geometrik forma dönüştürür. Konturun [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) yöntemi doldurulmasını devre dışı bırakır. Bir [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html), bir [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) içinde metin konturunu oluşturur. Bunun [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) hareket, çizgi, ikinci dereceden, kübik ve kapanış segmentlerini sağlar; örnek bu segmentleri bir [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) üzerine yeniden oynatır.

Java köprüsü, ilgili Java parametreleri için açıkça float ve byte değerleri kullanır. İteratör koordinatları bir Java float dizisine yazar; yansıma güncellenen değerleri JavaScript’e geri okur. Metin 40 puan Arial yazı tipindedir. Kontur, yatayda 20 puan kaydırılır ve şeklin üst kenarının 10 puan altında görsel üst konuma yerleştirilir. Metin yolu doldurulur, orijinal dikdörtgen ise sadece bir kontur kalır. Her iki yol da [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) ile uygulanarak dikdörtgen ve metni içeren tek bir şekil elde edilir.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // Taşı.
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // Çizgi çiz.
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // İkinci dereceden Bézier eğrisi.
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // Kübik Bézier eğrisi.
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // Şekli kapat.
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **SSS**

**Geometrinin yerini değiştirdikten sonra doldurma ve kontur ne olur?**

Stil şekil üzerinde kalır; sadece kontur değişir. Doldurma ve kontur yeni geometriye otomatik olarak uygulanır.

**Özel şekli ve geometrisini doğru şekilde nasıl döndürürüm?**

Şeklin [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) yöntemini kullanın; geometri şeklin kendi koordinat sistemine bağlı olduğu için şekille birlikte döner.

**Özel bir şekli bir görüntüye dönüştürerek sonucu “kilitleyebilir” miyim?**

Evet. İlgili [slide](/slides/tr/nodejs-java/convert-powerpoint-to-png/) alanını ya da [shape](/slides/tr/nodejs-java/create-shape-thumbnails/) kendisini raster formata dışa aktarın; bu, karmaşık geometrilerle çalışmayı basitleştirir.