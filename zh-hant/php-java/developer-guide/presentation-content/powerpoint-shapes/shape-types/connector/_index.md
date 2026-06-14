---
title: 使用 PHP 管理簡報中的連接線
linktitle: 連接線
type: docs
weight: 10
url: /zh-hant/php-java/connector/
keywords:
- 連接線
- 連接線類型
- 連接線點
- 連接線線條
- 連接線角度
- 連接圖形
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "賦能 PHP 應用程式在 PowerPoint 投影片中繪製、連接與自動路由線條 — 完全掌控直線、彎頭與曲線連接線。"
---
## **簡介**

PowerPoint 連接線是一種特殊的線條，可將兩個圖形連接或鏈接在一起，即使在投影片上移動或重新定位圖形時，仍會保持附著於圖形。

連接線通常連接到*連接點*（綠點），這些點預設存在於所有圖形上。當游標靠近時，連接點會顯示出來。

*調整點*（橙點），僅存在於某些連接線上，用於調整連接線的位置和形狀。

## **連接線類型**

在 PowerPoint 中，您可以使用直線、彎頭（角度）和曲線連接線。

Aspose.Slides 提供以下連接線：

| 連接線 | 圖片 | 調整點數量 |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType::Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType::BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType::BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType::BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType::BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType::CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType::CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType::CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType::CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **使用連接線連接圖形**

1. 建立 [Presentation](https://apireference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 使用 `Shapes` 物件提供的 `addAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/AutoShape) 新增至投影片。
4. 透過 `Shapes` 物件的 `addConnector` 方法，依據連接線類型新增連接線。
5. 使用連接線將圖形連接起來。
6. 呼叫 `reroute` 方法以套用最短的連接路徑。
7. 儲存簡報。

以下 PHP 程式碼示範如何在兩個圖形（橢圓與矩形）之間加入一條連接線（彎曲連接線）：

```php
// 實例化一個表示 PPTX 檔案的簡報類別
  $pres = new Presentation();
  try {
    # 取得特定投影片的圖形集合
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 新增一個橢圓自動圖形
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 新增一個矩形自動圖形
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 向投影片圖形集合新增連接線形狀
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 使用連接線將圖形連接起來
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 呼叫 reroute 方法以設定圖形之間的自動最短路徑
    $connector->reroute();
    # 儲存簡報
    $pres->save("output.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` 方法會重新路由連接線，強制其在圖形之間走最短路徑。為了達成此目的，該方法可能會變更 `setStartShapeConnectionSiteIndex` 和 `setEndShapeConnectionSiteIndex` 點。 
{{% /alert %}} 

## **指定連接點**

如果您想要讓連接線使用圖形上的特定點來連接兩個圖形，必須以以下方式指定您偏好的連接點：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 使用 `Shapes` 物件提供的 `addAutoShape` 方法，將兩個 [AutoShape](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/AutoShape) 新增至投影片。
4. 透過 `Shapes` 物件的 `addConnector` 方法，依據連接線類型新增連接線。
5. 使用連接線將圖形連接起來。
6. 在圖形上設定您偏好的連接點。
7. 儲存簡報。

以下 PHP 程式碼示範如何指定偏好的連接點：

```php
  # 實例化一個表示 PPTX 檔案的簡報類別
  $pres = new Presentation();
  try {
    # 取得特定投影片的圖形集合
    $shapes = $pres->getSlides()->get_Item(0)->getShapes();
    # 新增一個橢圓自動圖形
    $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
    # 新增一個矩形自動圖形
    $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
    # 向投影片的圖形集合新增連接線形狀
    $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
    # 使用連接線將圖形連接起來
    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    # 設定橢圓圖形上首選的連接點索引
    $wantedIndex = 6;
    # 檢查首選索引是否小於最大站點索引計數
    if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
      # 在橢圓自動圖形上設定首選的連接點
      $connector->setStartShapeConnectionSiteIndex($wantedIndex);
    }
    # 儲存簡報
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **調整連接線點**

您可以透過調整點來調整已有的連接線。只有具備調整點的連接線才能以此方式變更。請參考 **[連接線類型](/slides/zh-hant/php-java/connector/#types-of-connectors)** 下的表格。

### **簡單案例**

考慮一種情況，兩個圖形 (A 與 B) 之間的連接線穿過第三個圖形 (C)：

![connector-obstruction](connector-obstruction.png)

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setStartShapeConnectionSiteIndex(2);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

為了避免或繞過第三個圖形，我們可以透過將其垂直線向左移動來調整連接線：

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```php
  $adj2 = $connector->getAdjustments()->get_Item(1);
  $adj2->setRawValue($adj2->getRawValue() + 10000);

```

### **複雜案例**

執行更複雜的調整時，必須考慮以下事項：

* 連接線的可調整點與計算其位置的公式緊密相關。因此，點位置的變更可能會改變連接線的形狀。  
* 連接線的調整點在陣列中以嚴格順序定義，編號順序由連接線的起點到終點。  
* 調整點值反映連接線形狀寬度/高度的百分比。  
  * 形狀的範圍為連接線起點與終點乘以 1000 所得到的範圍。  
  * 第一點、第二點與第三點分別定義寬度的百分比、高度的百分比以及再次的寬度百分比。  
* 在計算連接線調整點座標時，必須考慮連接線的旋轉與翻轉。**注意**，所有在 **[連接線類型](/slides/zh-hant/php-java/connector/#types-of-connectors)** 中顯示的連接線之旋轉角度皆為 0。

#### **案例 1**

考慮一個案例，兩個文字框物件透過連接線相互連接：

![connector-shape-complex](connector-shape-complex.png)

```php
  # 實例化一個表示 PPTX 檔案的簡報類別
  $pres = new Presentation();
  try {
    # 取得簡報中的第一張投影片
    $sld = $pres->getSlides()->get_Item(0);
    # 新增將透過連接線連結在一起的圖形
    $shapeFrom = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $shapeFrom->getTextFrame()->setText("From");
    $shapeTo = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $shapeTo->getTextFrame()->setText("To");
    # 新增連接線
    $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    # 指定連接線的方向
    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    # 指定連接線的顏色
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # 指定連接線線條的粗細
    $connector->getLineFormat()->setWidth(3);
    # 使用連接線將圖形互相連結
    $connector->setStartShapeConnectedTo($shapeFrom);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($shapeTo);
    $connector->setEndShapeConnectionSiteIndex(2);
    # 取得連接線的調整點
    $adjValue_0 = $connector->getAdjustments()->get_Item(0);
    $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**調整**

我們可以透過分別將相應的寬度與高度百分比提升 20% 和 200% 來變更連接線的調整點值：

```php
  # 更改調整點的值
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

結果：

![connector-adjusted-1](connector-adjusted-1.png)

為了定義一個模型以取得連接線各部份的座標與形狀，讓我們建立一個對應於 `connector.getAdjustments().get_Item(0)` 點之水平元件的形狀：

```php
  # 繪製連接線的垂直元件
  $x = $connector->getX() . $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  $y = $connector->getY();
  $height = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 0, $height);
```

結果：

![connector-adjusted-2](connector-adjusted-2.png)

#### **案例 2**

在 **案例 1** 中，我們示範了使用基礎原理的簡單連接線調整操作。在一般情況下，必須考慮連接線的旋轉與顯示（由 `connector.getRotation()`、`connector.getFrame().getFlipH()` 以及 `connector.getFrame().getFlipV()` 設定）。現在將示範此過程。

首先，將一個新的文字框物件（**To 1**）新增至投影片（用於連接），並建立一條新的（綠色）連接線，將其連接至先前建立的物件。

```php
  # 建立新的綁定物件
  $shapeTo_1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
  $shapeTo_1->getTextFrame()->setText("To 1");
  # 建立新的連接線
  $connector = $sld->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
  $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
  $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
  $connector->getLineFormat()->setWidth(3);
  # 使用新建立的連接線連接物件
  $connector->setStartShapeConnectedTo($shapeFrom);
  $connector->setStartShapeConnectionSiteIndex(2);
  $connector->setEndShapeConnectedTo($shapeTo_1);
  $connector->setEndShapeConnectionSiteIndex(3);
  # 取得連接線的調整點
  $adjValue_0 = $connector->getAdjustments()->get_Item(0);
  $adjValue_1 = $connector->getAdjustments()->get_Item(1);
  # 變更調整點的值
  $adjValue_0->setRawValue($adjValue_0->getRawValue() + 20000);
  $adjValue_1->setRawValue($adjValue_1->getRawValue() + 200000);
```

結果：

![connector-adjusted-3](connector-adjusted-3.png)

其次，建立一個對應於穿過新連接線之調整點 `connector.getAdjustments().get_Item(0)` 的水平元件的形狀。我們將使用 `connector.getRotation()`、`connector.getFrame().getFlipH()` 與 `connector.getFrame().getFlipV()` 的值，並套用常用的繞給定點 x0 旋轉的座標轉換公式：

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

在本例中，物件的旋轉角度為 90 度，且連接線垂直顯示，因此對應的程式碼如下：

```php
  # 保存連接線座標
  $x = $connector->getX();
  $y = $connector->getY();
  # 校正連接線座標（如果需要）
  if ($connector->getFrame()->getFlipH() == NullableBool::True) {
    $x += $connector->getWidth();
  }
  if ($connector->getFrame()->getFlipV() == NullableBool::True) {
    $y += $connector->getHeight();
  }
  # 將調整點的值作為座標
  $x += $connector->getWidth() * $adjValue_0->getRawValue() / 100000;
  # 轉換座標，因為 Sin(90) = 1 且 Cos(90) = 0
  $xx = $connector->getFrame()->getCenterX() - $y . $connector->getFrame()->getCenterY();
  $yy = $x - $connector->getFrame()->getCenterX() . $connector->getFrame()->getCenterY();
  # 使用第二個調整點的值來決定水平元件的寬度
  $width = $connector->getHeight() * $adjValue_1->getRawValue() / 100000;
  $shape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, $xx, $yy, $width, 0);
  $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
  $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
```

結果：

![connector-adjusted-4](connector-adjusted-4.png)

我們展示了涉及簡單調整與具旋轉角度之複雜調整點的計算。運用所學，您可以自行開發模型（或撰寫程式碼）以取得 `GraphicsPath` 物件，甚至根據特定投影片座標設定連接線的調整點值。

## **找出連接線的角度**

1. 建立該類別的實例。
2. 透過索引取得投影片的參考。
3. 存取連接線形狀。
4. 使用線寬、線高、圖形框高度與圖形框寬度來計算角度。

以下 PHP 程式碼示範如何計算連接線形狀的角度：

```php
  $pres = new Presentation("ConnectorLineAngle.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($slide->getShapes()->size()) ; $i++) {
      $dir = 0.0;
      $shape = $slide->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $ashp = $shape;
        if ($ashp->getShapeType() == ShapeType::Line) {
          $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, $ashp->getFrame()->getFlipV() > 0);
        }
      } else if (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
        $ashp = $shape;
        $dir = getDirection($ashp->getWidth(), $ashp->getHeight(), java_values($ashp->getFrame()->getFlipH()) > 0, java_values($ashp->getFrame()->getFlipV()) > 0);
      }
      echo($dir);
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **常見問題**

**如何判斷連接線是否可以「黏貼」到特定圖形上？**

檢查該圖形是否提供 [連接點](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/shape/getconnectionsitecount/)。若無或計數為零，則無法黏貼；此時請使用自由端點並手動定位。建議在連接之前先檢查站點計數。

**如果刪除其中一個已連接的圖形，連接線會怎樣？**

其兩端會被分離；連接線會以普通線條的形式保留在投影片上，起點/終點為自由端。您可以刪除該線條，或重新指派連接，必要時使用 [reroute](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/connector/reroute/)。

**將投影片複製到另一個簡報時，連接線的綁定會被保留嗎？**

一般情況下會保留，只要同時複製了目標圖形。若將投影片插入至不包含已連接圖形的檔案中，端點會變為自由端，需重新連接。