---
title: TypeScript 支援
type: docs
weight: 65
url: /zh-hant/nodejs-java/typescript-support/
keywords:
- TypeScript
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 TypeScript 搭配 Aspose.Slides for Node.js 進行簡化的簡報管理。探索新功能與範例，以提升開發效率。"
---
## **簡介**

我們很高興宣佈為 [Aspose.Slides for Node.js via Java](https://www.npmjs.com/package/aspose.slides.via.java) 提供 **原生 TypeScript 支援**！此重大升級為 Node.js 中的 PowerPoint 自動化帶來現代化的開發工作流程。

## **主要優勢**

- **完整的 API 可探索性**: 為所有方法提供智慧的程式碼自動完成  
- **型別安全**: 在編譯時捕捉錯誤  
- **零設定**: 包含的 `.d.ts` 定義可即時使用  
- **Java 相容性**: 來自 Java 套件的所有公開方法皆已正確類型化  

## **技術實作**

型別定義會透過 `package.json` 自動載入：

```json
"types": "lib/aspose.slides.d.ts"
```

## **開發者體驗**

### **之前（純 JavaScript）**
```javascript
import * as AsposeSlides from 'aspose.slides.via.java';

// 沒有自動完成或類型檢查
const pres = new AsposeSlides.??? // 盲目操作
```

### **之後（TypeScript）**
```typescript
import * as AsposeSlides from 'aspose.slides.via.java';

const pres = new AsposeSlides.Presentation(); // 完整的自動完成
const slide = pres.getSlides().get_Item(0); // 正確的方法簽名
```

![TypeScript 自動完成示範](typedemo.png)  


## **開始使用**

1. 更新至最新版：  
```bash
npm install aspose.slides.via.java@latest
```

2. 若您使用 TypeScript，無需額外設定！