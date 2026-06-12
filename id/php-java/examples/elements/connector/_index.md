---
title: Konektor
type: docs
weight: 190
url: /id/php-java/examples/elements/connector/
keywords:
- konektor
- tambahkan konektor
- akses konektor
- hapus konektor
- sambungkan kembali bentuk
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Gambar dan kontrol konektor di PHP dengan Aspose.Slides: tambahkan, alur, alur ulang, atur titik koneksi, panah, dan gaya untuk menghubungkan bentuk dalam PPT, PPTX, dan ODP."
---
Menampilkan cara menghubungkan bentuk dengan konektor dan mengubah targetnya menggunakan **Aspose.Slides for PHP via Java**.

## **Add a Connector**
Menyisipkan bentuk konektor di antara dua titik pada slide.

```php
function addConnector() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $connector = $slide->Shapes->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $presentation->save("connector.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access a Connector**
Mengambil bentuk konektor pertama yang ditambahkan ke slide.

```php
function accessConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Akses konektor pertama pada slide.
        $firstConnector = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $firstConnector = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Connector**
Menghapus konektor dari slide.

```php
function removeConnector() {
    $presentation = new Presentation("connector.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dengan asumsi bahwa bentuk pertama pada slide adalah sebuah konektor.
        $connector = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($connector);

        $presentation->save("connector_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Reconnect Shapes**
Melampirkan konektor ke dua bentuk dengan menetapkan target awal dan akhir.

```php
function reconnectShapes() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
        $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

        $connector->setStartShapeConnectedTo($shape1);
        $connector->setEndShapeConnectedTo($shape2);

        $presentation->save("shapes_reconnected.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```