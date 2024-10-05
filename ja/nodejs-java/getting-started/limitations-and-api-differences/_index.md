---
title: 制限とAPIの違い
type: docs
weight: 100
url: /nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, differences"
description: "Aspose.Slides for Node.js via Javaの制限とAPIの違い。"
---

## **公開APIの違い**
以下のリスト（サンプルコードセグメント付き）は、Aspose.Slides for JavaとAspose.Slides for Node.js via Java APIsの間のいくつかの違いを示しています。

### **ライブラリのインポート（パッケージ比較）**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
```

### **新しいプレゼンテーションのインスタンス化**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **ファイルストリーミングと定数**

**Aspose.Slides for Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("プレゼンテーションを開くエラー");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('ファイルに保存されました');
});
```

### **Aspose.Slides for Node.js via Java APIの他の制限（Aspose.Slides for Java APIに対して）**
1. 配列、ArrayList、ResultSetなどからデータをインポート/エクスポートすることはサポートされていません。
1. 印刷はサポートされていません。