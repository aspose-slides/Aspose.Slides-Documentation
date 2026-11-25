---
title: "ขัดจังหวะการดำเนินงานการนำเสนอที่ใช้เวลานานใน Node.js"
linktitle: "ขัดจังหวะการดำเนินงานการนำเสนอ"
type: docs
weight: 120
url: /th/nodejs-java/support-for-interruptable-library/
keywords:
- "การดำเนินการที่สามารถขัดจังหวะได้"
- "โทเคนการขัดจังหวะ"
- "โทเคนการยกเลิก"
- "เวลาจำกัดการแปลง"
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "ยกเลิกการดำเนินงานการนำเสนอที่ใช้เวลานานใน Aspose.Slides for Node.js via Java ตั้งเวลาจำกัดการแปลง และติดตามสไลด์ที่ส่งออกก่อนการยกเลิก."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java รองรับการยกเลิกเมื่อทำการโหลด, บันทึก หรือแสดงผลการนำเสนอ คุณยังสามารถตรวจสอบโทเคนเดียวกันในลูปการส่งออกของคุณเพื่อหยุดก่อนสไลด์ถัดไปและคืนหมายเลขของสไลด์ที่บันทึกแล้ว

## **ขัดขวางการทำงานของการนำเสนอ**

สร้าง [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), รับโทเคนด้วย [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) แล้วส่งต่อให้กับ [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken) ใช้ตัวเลือกเหล่านี้เมื่อสร้าง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) การเรียก [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) บนแหล่งข้อมูลจะร้องขอยกเลิกการทำงานปัจจุบัน Aspose.Slides จะหยุดเมื่อทำการตรวจสอบโทเคนครั้งต่อไป

### **ตั้งค่าเวลาจำกัดการแปลง**

ตัวอย่างต่อไปนี้อนุญาตให้ใช้เวลา 20 วินาทีเพื่อเปิด `sample.pptx` และบันทึกเป็น `sample.pdf` ทั้งคอนสตรัคเตอร์และการบันทึกทำงานแบบอะซิงโครนัสผ่าน Java bridge ทำให้ตัวจับเวลา Node.js สามารถทำงานระหว่างการดำเนินการใดๆ ตัวอย่างตรวจสอบโทเคนหลังจากการโหลดและอีกครั้งหลังการบันทึก เนื่องจากการเรียกไลบรารีอาจคืนค่าหลังจากคำขอยกเลิก จะปล่อยการนำเสนอเมื่อการทำงานเสร็จสิ้นและล้างตัวจับเวลา หากการแปลงเสร็จเร็ว ตัวจับเวลาจะถูกล้าง หากเกิดการยกเลิกระหว่างการบันทึก ไฟล์ผลลัพธ์อาจมีอยู่แล้วแต่ไม่สมบูรณ์

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

เพื่อแปลงเป็นรูปแบบ PowerPoint เก่าโดยจำกัดเวลา 10 วินาที ให้ส่ง `"sample.ppt"`, `slides.SaveFormat.Ppt` และ `10000` เป็นอาร์กิวเมนต์สามตัวสุดท้าย

## **หยุดก่อนประมวลผลสไลด์ถัดไป**

ใช้ [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) ก่อนทำการส่งออกแต่ละครั้งเมื่อผู้เรียกสามารถใช้ผลลัพธ์บางส่วนได้ การ overload ของ [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) สำหรับสไลด์ที่เลือกรับอาร์เรย์ Java `int[]` ของหมายเลขสไลด์ เริ่มจาก 1 บันทึกหมายเลขแต่ละตัวเฉพาะเมื่อตรวจสอบว่า PDF ของมันบันทึกสำเร็จแล้ว

เรียกใช้ตัวอย่างโดยใช้การนำเสนอชื่อ `sample.pptx` ที่มีอย่างน้อยสองสไลด์ เพื่อสาธิตการยกเลิกระหว่างการส่งออก ตัวอย่างจะร้องขอยกเลิกทันทีหลังจากบันทึกสไลด์แรก

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

ตัวอย่างจะเขียน `slide-1.pdf` และพิมพ์ `Starting slide 1` ตามด้วย `Completed: [1]` ลูปจะตรวจพบการยกเลิกก่อนเริ่มสไลด์ที่ 2 หากการบันทึกเองถูกรบกวน รายการที่คืนค่าจะมีเพียงการส่งออกที่สำเร็จก่อนหน้าเท่านั้น

เพื่อให้ผู้เรียกจัดการการยกเลิกเป็นข้อผิดพลาด ให้แทนที่การตรวจสอบและ `break` ที่ส่วนหัวของลูปด้วย [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) เรียกเป็น `token.throwIfInterruptionRequested()` ใช้การตรวจสอบแบบโยนข้อยกเว้นนี้หลังการบันทึกและลบ `try`/`catch` รอบ ๆ มัน ด้วยอินพุตเดียวกัน PDF แรกยังคงถูกเขียนและการวนรอบที่สองจะโยนข้อยกเว้นก่อนฟังก์ชันจะคืนค่ารายการ

## **คำถามที่พบบ่อย**

**ควรร้องขอยกเลิกเมื่อใด?**

ร้องขอยกเลิกเมื่อกำหนดเวลาหมดหรือแอปพลิเคชันไม่ต้องการผลลัพธ์อีกต่อไป การโหลด, การบันทึก และการแสดงผลทั้งหมดสามารถใช้โทเคนที่ส่งให้กับการนำเสนอขณะสร้างได้

**แหล่งข้อมูลและโทเคนต่างกันอย่างไร?**

แหล่งข้อมูลให้แอปพลิเคชันร้องขอยกเลิก ส่วนโทเคนให้ Aspose.Slides และโค้ดของคุณตรวจสอบคำขอนั้น

**ตัวจับเวลา Node.js สามารถขัดจังหวะการบันทึกแบบซิงโครนัสได้หรือไม่?**

การบันทึกแบบซิงโครนัสจะบล็อก JavaScript บนเธรดที่เรียกใช้ ใช้การเรียก Java bridge แบบอะซิงโครนัสตามตัวอย่างการตั้งเวลาจำกัด เพื่อให้ตัวจับเวลาสามารถร้องขอยกเลิกได้ขณะการบันทึกทำงาน

**การยกเลิกมีผลทันทีหรือไม่?**

การยกเลิกเป็นการทำงานร่วมกัน การดำเนินการที่กำลังทำงานจะหยุดเมื่อสังเกตเห็นคำขอ การดำเนินการที่เสร็จสิ้นแล้วจะคงผลลัพธ์ไว้

**หลายการดำเนินการสามารถใช้แหล่งข้อมูลเดียวกันได้หรือไม่?**

ได้ การเรียก `interrupt()` จะร้องขอยกเลิกสำหรับการดำเนินการทุกอย่างที่ใช้โทเคนจากแหล่งข้อมูลนั้น ใช้แหล่งข้อมูลแยกกันสำหรับแต่ละการดำเนินการที่ต้องการยกเลิกอย่างอิสระ