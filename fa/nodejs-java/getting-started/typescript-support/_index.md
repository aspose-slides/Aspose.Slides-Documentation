---
title: پشتیبانی TypeScript
type: docs
weight: 65
url: /fa/nodejs-java/typescript-support/
keywords:
- تایپ اسکریپت
- پاورپوینت
- سند باز
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "از TypeScript با Aspose.Slides برای Node.js برای مدیریت ساده‌سازی شده ارائه‌ها استفاده کنید. ویژگی‌ها و مثال‌های جدید را برای افزایش کارایی توسعه بررسی کنید."
---
## **معرفی**

ما خوشحالیم که **پشتیبانی بومی TypeScript** را برای [Aspose.Slides for Node.js via Java](https://www.npmjs.com/package/aspose.slides.via.java) اعلام کنیم! این به‌روزرسانی بزرگ، جریان‌های کاری مدرن توسعه را به خودکارسازی PowerPoint در Node.js می‌آورد.

## **فواید کلیدی**

- **کشف کامل API**: تکمیل هوشمند کد برای همه متدها را دریافت کنید
- **ایمنی نوع**: خطاها را در زمان کامپایل شناسایی کنید
- **بدون تنظیمات**: به‌صورت پیش‌فرض با تعریف‌های `.d.ts` گنجانده شده کار می‌کند
- **تطابق با Java**: تمام متدهای عمومی بسته Java به‌درستی تایپ شده‌اند

## **پیاده‌سازی فنی**

تعریف‌های نوع به‌صورت خودکار از طریق `package.json` بارگذاری می‌شوند:

```json
"types": "lib/aspose.slides.d.ts"
```

## **تجربه توسعه‌دهنده**

### **قبل (JavaScript ساده)**
```javascript
import * as AsposeSlides from 'aspose.slides.via.java';

// بدون تکمیل خودکار یا بررسی نوع
const pres = new AsposeSlides.??? // پرواز به صورت کور
```

### **بعد (TypeScript)**
```typescript
import * as AsposeSlides from 'aspose.slides.via.java';

const pres = new AsposeSlides.Presentation(); // تکمیل خودکار کامل
const slide = pres.getSlides().get_Item(0); // امضاهای صحیح متدها
```

![Demo تکمیل خودکار TypeScript](typedemo.png)  

## **شروع کار**

1. به‌روز رسانی به آخرین نسخه:
```bash
npm install aspose.slides.via.java@latest
```

2. اگر از TypeScript استفاده می‌کنید، نیازی به پیکربندی اضافی نیست!